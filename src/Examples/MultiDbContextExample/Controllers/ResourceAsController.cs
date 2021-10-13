using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;
using MultiDbContextExample.Models;

namespace MultiDbContextExample.Controllers
{
    public sealed class ResourceAsController : JsonApiController<ResourceA, int>
    {
        public ResourceAsController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<ResourceA, int> resourceService)
            : base(options, loggerFactory, resourceService)
        {
        }
    }
}
