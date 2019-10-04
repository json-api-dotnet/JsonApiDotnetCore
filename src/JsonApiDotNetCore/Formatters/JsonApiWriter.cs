using System;
using System.Text;
using System.Threading.Tasks;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Managers.Contracts;
using JsonApiDotNetCore.Serialization.Server;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace JsonApiDotNetCore.Formatters
{
    public class JsonApiWriter : IJsonApiWriter
    {
        private readonly ILogger<JsonApiWriter> _logger;
        private readonly IJsonApiSerializer _serializer;
        private readonly ICurrentRequest _currentRequest;

        public JsonApiWriter(ICurrentRequest currentRequest,
                             IJsonApiSerializerFactory factory,
                             ILoggerFactory loggerFactory)
        {
            _serializer = factory.GetSerializer();
            _logger = loggerFactory.CreateLogger<JsonApiWriter>();
            _currentRequest = currentRequest;
        }

        public async Task WriteAsync(OutputFormatterWriteContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;
            using (var writer = context.WriterFactory(response.Body, Encoding.UTF8))
            {
                response.ContentType = Constants.ContentType;
                string responseContent;
                try
                {
                    responseContent = GetResponseBody(context.Object);
                }
                catch (Exception e)
                {
                    _logger?.LogError(new EventId(), e, "An error ocurred while formatting the response");
                    responseContent = GetErrorResponse(e);
                    response.StatusCode = 400;
                }

                await writer.WriteAsync(responseContent);
                await writer.FlushAsync();
            }
        }

        private string GetResponseBody(object responseObject) => _serializer.Serialize(responseObject, _currentRequest.RequestRelationship);
        private string GetErrorResponse(Exception e)
        {
            var errors = new ErrorCollection();
            errors.Add(new Error(400, e.Message, ErrorMeta.FromException(e)));
            return errors.GetJson();
        }
    }
}
