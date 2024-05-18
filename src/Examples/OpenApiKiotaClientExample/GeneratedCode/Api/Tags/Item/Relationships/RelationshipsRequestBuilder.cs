// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaClientExample.GeneratedCode.Api.Tags.Item.Relationships.TodoItems;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Api.Tags.Item.Relationships {
    /// <summary>
    /// Builds and executes requests for operations under \api\tags\{id}\relationships
    /// </summary>
    public class RelationshipsRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>The todoItems property</summary>
        public TodoItemsRequestBuilder TodoItems
        {
            get => new TodoItemsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api/tags/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api/tags/{id}/relationships", rawUrl)
        {
        }
    }
}
