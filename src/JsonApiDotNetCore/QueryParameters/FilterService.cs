using System;
using System.Collections.Generic;
using System.Linq;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Internal.Query;
using JsonApiDotNetCore.Managers.Contracts;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;

namespace JsonApiDotNetCore.Query
{
    /// <summary>
    /// Abstracts away the creation of the corresponding generic type and usage
    /// of the service provider in order to get a <see cref="ResourceDefinition{TResource}"/>
    /// service.
    /// </summary>
    internal class ResourceDefinitionProvider : IResourceDefinitionProvider
    {
        private readonly IScopedServiceProvider _sp;
        private readonly IContextEntityProvider _rcp;

        public ResourceDefinitionProvider(IContextEntityProvider resourceContextProvider, IScopedServiceProvider serviceProvider)
        {
            _sp = serviceProvider;
            _rcp = resourceContextProvider;
        }

        /// <inheritdoc/>
        public IResourceDefinition Get(Type resourceType)
        {
            return (IResourceDefinition)_sp.GetService(_rcp.GetContextEntity(resourceType).ResourceType);
        }
    }


    public class FilterService : QueryParameterService, IFilterService
    {

        private readonly List<FilterQuery> _filters;
        public FilterService(ICurrentRequest currentRequest, IResourceDefinitionProvider rdProvider)
        {
            _filters = new List<FilterQuery>();
        }

        public List<FilterQuery> Get()
        {
            return _filters;
        }

        public override void Parse(string key, string value)
        {
            // expected input = filter[id]=1
            // expected input = filter[id]=eq:1
            var queries = new List<FilterQuery>();
            var propertyName = key.Split(QueryConstants.OPEN_BRACKET, QueryConstants.CLOSE_BRACKET)[1];

            // InArray case
            string op = GetFilterOperation(value);
            if (string.Equals(op, FilterOperations.@in.ToString(), StringComparison.OrdinalIgnoreCase)
                || string.Equals(op, FilterOperations.nin.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                (var _, var filterValue) = ParseFilterOperation(value);
                // should add logic to check if propertyNamer even exists.
                queries.Add(new FilterQuery(propertyName, filterValue, op));
            }
            else
            {
                var values = value.Split(QueryConstants.COMMA);
                foreach (var val in values)
                {
                    (var operation, var filterValue) = ParseFilterOperation(val);
                    queries.Add(new FilterQuery(propertyName, filterValue, operation));
                }
            }

            _filters.AddRange(queries);
        }

        private (string operation, string value) ParseFilterOperation(string value)
        {
            if (value.Length < 3)
                return (string.Empty, value);

            var operation = GetFilterOperation(value);
            var values = value.Split(QueryConstants.COLON);

            if (string.IsNullOrEmpty(operation))
                return (string.Empty, value);

            value = string.Join(QueryConstants.COLON_STR, values.Skip(1));

            return (operation, value);
        }

        private string GetFilterOperation(string value)
        {
            var values = value.Split(QueryConstants.COLON);

            if (values.Length == 1)
                return string.Empty;

            var operation = values[0];
            // remove prefix from value
            if (Enum.TryParse(operation, out FilterOperations op) == false)
                return string.Empty;

            return operation;
        }
    }
}
