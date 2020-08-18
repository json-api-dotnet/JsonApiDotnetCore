using System.Reflection;
using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.QueryStrings;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JsonApiDotNetCore.Middleware
{
    public sealed class QueryStringActionFilter : IAsyncActionFilter, IQueryStringActionFilter
    {
        private readonly IQueryStringReader _queryStringReader;

        public QueryStringActionFilter(IQueryStringReader queryStringReader)
        {
            _queryStringReader = queryStringReader;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            DisableQueryStringAttribute disableQueryStringAttribute = context.Controller.GetType().GetCustomAttribute<DisableQueryStringAttribute>();

            _queryStringReader.ReadAll(disableQueryStringAttribute);
            await next();
        }
    }
}
