using System.Collections.Generic;
using System.Linq;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries;

namespace JsonApiDotNetCore.Serialization.Building
{
    /// <inheritdoc />
    public class MetaBuilder : IMetaBuilder
    {
        private readonly IPaginationContext _paginationContext;
        private readonly IJsonApiOptions _options;
        private readonly IResponseMeta _responseMeta;

        private Dictionary<string, object> _meta = new Dictionary<string, object>();

        public MetaBuilder(IPaginationContext paginationContext, IJsonApiOptions options, IResponseMeta responseMeta)
        {
            ArgumentGuard.NotNull(paginationContext, nameof(paginationContext));
            ArgumentGuard.NotNull(options, nameof(options));
            ArgumentGuard.NotNull(responseMeta, nameof(responseMeta));

            _paginationContext = paginationContext;
            _options = options;
            _responseMeta = responseMeta;
        }

        /// <inheritdoc />
        public void Add(IReadOnlyDictionary<string, object> values)
        {
            ArgumentGuard.NotNull(values, nameof(values));

            _meta = values.Keys.Union(_meta.Keys)
                .ToDictionary(key => key,
                    key => values.ContainsKey(key) ? values[key] : _meta[key]);
        }

        /// <inheritdoc />
        public IDictionary<string, object> Build()
        {
            if (_paginationContext.TotalResourceCount != null)
            {
                string key = _options.SerializerNamingStrategy.GetPropertyName("TotalResources", false);

                _meta.Add(key, _paginationContext.TotalResourceCount);
            }

            var extraMeta = _responseMeta.GetMeta();
            if (extraMeta != null)
            {
                Add(extraMeta);
            }

            return _meta.Any() ? _meta : null;
        }
    }
}
