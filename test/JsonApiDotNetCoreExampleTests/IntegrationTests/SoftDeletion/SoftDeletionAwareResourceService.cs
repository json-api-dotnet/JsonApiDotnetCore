using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Repositories;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.SoftDeletion
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class SoftDeletionAwareResourceService<TResource, TId> : JsonApiResourceService<TResource, TId>
        where TResource : class, IIdentifiable<TId>
    {
        private readonly ISystemClock _systemClock;
        private readonly ITargetedFields _targetedFields;
        private readonly IResourceRepositoryAccessor _repositoryAccessor;
        private readonly IJsonApiRequest _request;

        public SoftDeletionAwareResourceService(ISystemClock systemClock, ITargetedFields targetedFields, IResourceRepositoryAccessor repositoryAccessor,
            IQueryLayerComposer queryLayerComposer, IPaginationContext paginationContext, IJsonApiOptions options, ILoggerFactory loggerFactory,
            IJsonApiRequest request, IResourceChangeTracker<TResource> resourceChangeTracker, IResourceDefinitionAccessor resourceDefinitionAccessor)
            : base(repositoryAccessor, queryLayerComposer, paginationContext, options, loggerFactory, request, resourceChangeTracker,
                resourceDefinitionAccessor)
        {
            _systemClock = systemClock;
            _targetedFields = targetedFields;
            _repositoryAccessor = repositoryAccessor;
            _request = request;
        }

        // To optimize performance, the default resource service does not always fetch all resources on write operations.
        // We do that here, to assure a 404 error is thrown for soft-deleted resources.

        public override async Task<TResource> CreateAsync(TResource resource, CancellationToken cancellationToken)
        {
            if (_targetedFields.Relationships.Any(relationship => IsSoftDeletable(relationship.RightType)))
            {
                await AssertResourcesToAssignInRelationshipsExistAsync(resource, cancellationToken);
            }

            return await base.CreateAsync(resource, cancellationToken);
        }

        public override async Task<TResource> UpdateAsync(TId id, TResource resource, CancellationToken cancellationToken)
        {
            if (_targetedFields.Relationships.Any(relationship => IsSoftDeletable(relationship.RightType)))
            {
                await AssertResourcesToAssignInRelationshipsExistAsync(resource, cancellationToken);
            }

            return await base.UpdateAsync(id, resource, cancellationToken);
        }

        public override async Task SetRelationshipAsync(TId primaryId, string relationshipName, object secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            if (IsSoftDeletable(_request.Relationship.RightType))
            {
                await AssertRightResourcesExistAsync(secondaryResourceIds, cancellationToken);
            }

            await base.SetRelationshipAsync(primaryId, relationshipName, secondaryResourceIds, cancellationToken);
        }

        public override async Task AddToToManyRelationshipAsync(TId primaryId, string relationshipName, ISet<IIdentifiable> secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            if (IsSoftDeletable(typeof(TResource)))
            {
                _ = await GetPrimaryResourceByIdAsync(primaryId, TopFieldSelection.OnlyIdAttribute, cancellationToken);
            }

            if (IsSoftDeletable(_request.Relationship.RightType))
            {
                await AssertRightResourcesExistAsync(secondaryResourceIds, cancellationToken);
            }

            await base.AddToToManyRelationshipAsync(primaryId, relationshipName, secondaryResourceIds, cancellationToken);
        }

        public override async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (IsSoftDeletable(typeof(TResource)))
            {
                await SoftDeleteAsync(id, cancellationToken);
            }
            else
            {
                await base.DeleteAsync(id, cancellationToken);
            }
        }

        private async Task SoftDeleteAsync(TId id, CancellationToken cancellationToken)
        {
            TResource resourceFromDatabase = await GetPrimaryResourceForUpdateAsync(id, cancellationToken);

            ((ISoftDeletable)resourceFromDatabase).SoftDeletedAt = _systemClock.UtcNow;

            // A delete operation does not target any fields, so we can just pass resourceFromDatabase twice.
            await _repositoryAccessor.UpdateAsync(resourceFromDatabase, resourceFromDatabase, cancellationToken);
        }

        private static bool IsSoftDeletable(Type resourceType)
        {
            return typeof(ISoftDeletable).IsAssignableFrom(resourceType);
        }
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class SoftDeletionAwareResourceService<TResource> : SoftDeletionAwareResourceService<TResource, int>, IResourceService<TResource>
        where TResource : class, IIdentifiable<int>
    {
        public SoftDeletionAwareResourceService(ISystemClock systemClock, ITargetedFields targetedFields, IResourceRepositoryAccessor repositoryAccessor,
            IQueryLayerComposer queryLayerComposer, IPaginationContext paginationContext, IJsonApiOptions options, ILoggerFactory loggerFactory,
            IJsonApiRequest request, IResourceChangeTracker<TResource> resourceChangeTracker, IResourceDefinitionAccessor resourceDefinitionAccessor)
            : base(systemClock, targetedFields, repositoryAccessor, queryLayerComposer, paginationContext, options, loggerFactory, request,
                resourceChangeTracker, resourceDefinitionAccessor)
        {
        }
    }
}
