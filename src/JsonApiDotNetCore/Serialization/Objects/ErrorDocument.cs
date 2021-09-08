using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using JetBrains.Annotations;

namespace JsonApiDotNetCore.Serialization.Objects
{
    [PublicAPI]
    public sealed class ErrorDocument
    {
        public IReadOnlyList<ErrorObject> Errors { get; }

        public ErrorDocument()
            : this(Array.Empty<ErrorObject>())
        {
        }

        public ErrorDocument(ErrorObject error)
            : this(error.AsEnumerable())
        {
        }

        public ErrorDocument(IEnumerable<ErrorObject> errors)
        {
            ArgumentGuard.NotNull(errors, nameof(errors));

            Errors = errors.ToList();
        }

        public HttpStatusCode GetErrorStatusCode()
        {
            int[] statusCodes = Errors.Select(error => (int)error.StatusCode).Distinct().ToArray();

            if (statusCodes.Length == 1)
            {
                return (HttpStatusCode)statusCodes[0];
            }

            int statusCode = int.Parse($"{statusCodes.Max().ToString()[0]}00");
            return (HttpStatusCode)statusCode;
        }
    }
}
