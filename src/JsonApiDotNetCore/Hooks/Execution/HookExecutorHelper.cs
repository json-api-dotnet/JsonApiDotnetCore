using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Internal.Generics;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Extensions;
using PrincipalType = System.Type;
using DependentType = System.Type;
using Microsoft.EntityFrameworkCore;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Configuration;

namespace JsonApiDotNetCore.Hooks
{
    /// <inheritdoc/>
    internal class HookExecutorHelper : IHookExecutorHelper
    {
        private readonly IdentifiableComparer _comparer = new IdentifiableComparer();
        private readonly IJsonApiOptions _options;
        protected readonly IGenericProcessorFactory _genericProcessorFactory;
        protected readonly Dictionary<DependentType, IResourceHookContainer> _hookContainers;
        protected readonly Dictionary<DependentType, IHooksDiscovery> _hookDiscoveries;
        protected readonly List<ResourceHook> _targetedHooksForRelatedEntities;

        public HookExecutorHelper(IGenericProcessorFactory genericProcessorFactory,
                                  IJsonApiOptions options)
        {
            _options = options;
            _genericProcessorFactory = genericProcessorFactory;
            _hookContainers = new Dictionary<DependentType, IResourceHookContainer>();
            _hookDiscoveries = new Dictionary<DependentType, IHooksDiscovery>();
            _targetedHooksForRelatedEntities = new List<ResourceHook>();
        }

        /// <inheritdoc/>
        public IResourceHookContainer GetResourceHookContainer(DependentType dependentType, ResourceHook hook = ResourceHook.None)
        {
            /// checking the cache if we have a reference for the requested container, 
            /// regardless of the hook we will use it for. If the value is null, 
            /// it means there was no implementation IResourceHookContainer at all, 
            /// so we need not even bother.
            if (!_hookContainers.TryGetValue(dependentType, out IResourceHookContainer container))
            {
                container = (_genericProcessorFactory.GetProcessor<IResourceHookContainer>(typeof(ResourceDefinition<>), dependentType));
                _hookContainers[dependentType] = container;
            }
            if (container == null) return container;

            /// if there was a container, first check if it implements the hook we 
            /// want to use it for.
            List<ResourceHook> targetHooks;
            if (hook == ResourceHook.None)
            {
                CheckForTargetHookExistence();
                targetHooks = _targetedHooksForRelatedEntities;
            }
            else
            {
                targetHooks = new List<ResourceHook>() { hook };
            }

            foreach (ResourceHook targetHook in targetHooks)
            {
                if (ShouldExecuteHook(dependentType, targetHook)) return container;
            }
            return null;
        }

        /// <inheritdoc/>
        public IResourceHookContainer<TResource> GetResourceHookContainer<TResource>(ResourceHook hook = ResourceHook.None) where TResource : class, IIdentifiable
        {
            return (IResourceHookContainer<TResource>)GetResourceHookContainer(typeof(TResource), hook);
        }

        public IEnumerable LoadDbValues(PrincipalType entityTypeForRepository, IEnumerable entities, ResourceHook hook, params RelationshipAttribute[] inclusionChain)
        {
            var idType = TypeHelper.GetIdentifierType(entityTypeForRepository);
            var parameterizedGetWhere = GetType()
                    .GetMethod(nameof(GetWhereAndInclude), BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(entityTypeForRepository, idType);
            var casted = ((IEnumerable<object>)entities).Cast<IIdentifiable>();
            var ids = casted.Select(e => e.StringId).Cast(idType);
            var values = (IEnumerable)parameterizedGetWhere.Invoke(this, new object[] { ids, inclusionChain });
            if (values == null) return null;
            return (IEnumerable)Activator.CreateInstance(typeof(HashSet<>).MakeGenericType(entityTypeForRepository), values.Cast(entityTypeForRepository));
        }

        public HashSet<TResource> LoadDbValues<TResource>(IEnumerable<TResource> entities, ResourceHook hook, params RelationshipAttribute[] relationships) where TResource : class, IIdentifiable
        {
            var entityType = typeof(TResource);
            var dbValues = LoadDbValues(entityType, entities, hook, relationships)?.Cast<TResource>();
            if (dbValues == null) return null;
            return new HashSet<TResource>(dbValues);
        }

        public bool ShouldLoadDbValues(Type entityType, ResourceHook hook)
        {
            var discovery = GetHookDiscovery(entityType);
            if (discovery.DatabaseValuesDisabledHooks.Contains(hook))
                return false;
            if (discovery.DatabaseValuesEnabledHooks.Contains(hook))
                return true;
            return _options.LoaDatabaseValues;
        }

        bool ShouldExecuteHook(DependentType entityType, ResourceHook hook)
        {
            var discovery = GetHookDiscovery(entityType);
            return discovery.ImplementedHooks.Contains(hook);
        }


        void CheckForTargetHookExistence()
        {
            if (!_targetedHooksForRelatedEntities.Any())
                throw new InvalidOperationException("Something is not right in the breadth first traversal of resource hook: " +
                    "trying to get meta information when no allowed hooks are set");
        }

        IHooksDiscovery GetHookDiscovery(Type entityType)
        {
            if (!_hookDiscoveries.TryGetValue(entityType, out IHooksDiscovery discovery))
            {
                discovery = _genericProcessorFactory.GetProcessor<IHooksDiscovery>(typeof(IHooksDiscovery<>), entityType);
                _hookDiscoveries[entityType] = discovery;
            }
            return discovery;
        }

        IEnumerable<TResource> GetWhereAndInclude<TResource, TId>(IEnumerable<TId> ids, RelationshipAttribute[] inclusionChain) where TResource : class, IIdentifiable<TId>
        {
            var repo = GetRepository<TResource, TId>();
            var query = repo.Get().Where(e => ids.Contains(e.Id));
            return repo.Include(query, inclusionChain).ToList();
        }

        IResourceReadRepository<TResource, TId> GetRepository<TResource, TId>() where TResource : class, IIdentifiable<TId>
        {
            return _genericProcessorFactory.GetProcessor<IResourceReadRepository<TResource, TId>>(typeof(IResourceReadRepository<,>), typeof(TResource), typeof(TId));
        }


        public Dictionary<RelationshipAttribute, IEnumerable> LoadImplicitlyAffected(
            Dictionary<RelationshipAttribute, IEnumerable> principalEntitiesByRelation,
            IEnumerable existingDependentEntities = null)
        {
            var implicitlyAffected = new Dictionary<RelationshipAttribute, IEnumerable>();
            foreach (var kvp in principalEntitiesByRelation)
            {
                if (IsHasManyThrough(kvp, out var principals, out var relationship)) continue;

                // note that we dont't have to check if BeforeImplicitUpdate hook is implemented. If not, it wont ever get here.
                var includedPrincipals = LoadDbValues(relationship.PrincipalType, principals, ResourceHook.BeforeImplicitUpdateRelationship, relationship);

                foreach (IIdentifiable ip in includedPrincipals)
                {
                    IList dbDependentEntityList = null;
                    var relationshipValue = relationship.GetValue(ip);
                    if (!(relationshipValue is IEnumerable))
                    {
                        dbDependentEntityList = TypeHelper.CreateListFor(relationship.DependentType);
                        if (relationshipValue != null) dbDependentEntityList.Add(relationshipValue);
                    }
                    else
                    {
                        dbDependentEntityList = (IList)relationshipValue;
                    }
                    var dbDependentEntityListCasted = dbDependentEntityList.Cast<IIdentifiable>().ToList();
                    if (existingDependentEntities != null) dbDependentEntityListCasted = dbDependentEntityListCasted.Except(existingDependentEntities.Cast<IIdentifiable>(), _comparer).ToList();

                    if (dbDependentEntityListCasted.Any())
                    {
                        if (!implicitlyAffected.TryGetValue(relationship, out IEnumerable affected))
                        {
                            affected = TypeHelper.CreateListFor(relationship.DependentType);
                            implicitlyAffected[relationship] = affected;
                        }
                        ((IList)affected).AddRange(dbDependentEntityListCasted);
                    }
                }
            }

            return implicitlyAffected.ToDictionary(kvp => kvp.Key, kvp => TypeHelper.CreateHashSetFor(kvp.Key.DependentType, kvp.Value));

        }

        private IEnumerable CreateHashSet(Type type, IList elements)
        {
            return (IEnumerable)Activator.CreateInstance(typeof(HashSet<>).MakeGenericType(type), new object[] { elements });
        }

        bool IsHasManyThrough(KeyValuePair<RelationshipAttribute, IEnumerable> kvp,
            out IEnumerable entities,
            out RelationshipAttribute attr)
        {
            attr = kvp.Key;
            entities = (kvp.Value);
            return (kvp.Key is HasManyThroughAttribute);
        }
    }
}
