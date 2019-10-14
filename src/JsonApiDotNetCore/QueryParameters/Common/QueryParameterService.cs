﻿using System.Linq;
using System.Text.RegularExpressions;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Managers.Contracts;
using JsonApiDotNetCore.Models;

namespace JsonApiDotNetCore.Query
{
    public abstract class QueryParameterService : IParsableQueryParameter
    {
        protected readonly IContextEntityProvider _contextEntityProvider;
        protected readonly ContextEntity _requestResource;

        protected QueryParameterService(IContextEntityProvider contextEntityProvider, ICurrentRequest currentRequest)
        {
            _contextEntityProvider = contextEntityProvider;
            _requestResource = currentRequest.GetRequestResource();
        }

        protected QueryParameterService() { }
        /// <summary>
        /// By default, the name is derived from the implementing type.
        /// </summary>
        /// <example>
        /// The following query param service will match the query  displayed in URL
        /// `?include=some-relationship`
        /// <code>public class IncludeService : QueryParameterService  { /* ... */  } </code>
        /// </example>
        public virtual string Name { get { return GetParameterNameFromType(); } }

        /// <inheritdoc/>
        public abstract void Parse(string key, string value);

        /// <summary>
        /// Gets the query parameter name from the implementing class name. Trims "Service"
        /// from the name if present.
        /// </summary>
        private string GetParameterNameFromType() => new Regex("Service$").Replace(GetType().Name, string.Empty).ToLower();

        protected AttrAttribute GetAttribute(string target, RelationshipAttribute relationship = null)
        {
            AttrAttribute attribute;
            if (relationship != null)
            {
                var relatedContextEntity = _contextEntityProvider.GetContextEntity(relationship.DependentType);
                attribute = relatedContextEntity.Attributes
                  .FirstOrDefault(a => a.Is(target));
            }
            else
            {
                attribute = _requestResource.Attributes.FirstOrDefault(attr => attr.Is(target));
            }

            if (attribute == null)
                throw new JsonApiException(400, $"'{target}' is not a valid attribute.");


            return attribute;
        }

        protected RelationshipAttribute GetRelationship(string propertyName)
        {
            if (propertyName == null) return null;
            var relationship = _requestResource.Relationships.FirstOrDefault(r => r.Is(propertyName));
            if (relationship == null)
                throw new JsonApiException(400, $"{propertyName} is not a valid relationship on {_requestResource.EntityName}.");


            return relationship;
        }
    }
}
