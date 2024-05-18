// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaClientExample.GeneratedCode.Api.People;
using OpenApiKiotaClientExample.GeneratedCode.Api.Tags;
using OpenApiKiotaClientExample.GeneratedCode.Api.TodoItems;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Api {
    /// <summary>
    /// Builds and executes requests for operations under \api
    /// </summary>
    public class ApiRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>The people property</summary>
        public PeopleRequestBuilder People
        {
            get => new PeopleRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The tags property</summary>
        public TagsRequestBuilder Tags
        {
            get => new TagsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The todoItems property</summary>
        public TodoItemsRequestBuilder TodoItems
        {
            get => new TodoItemsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="ApiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="ApiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api", rawUrl)
        {
        }
    }
}
