// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes
{
    /// <summary>
    /// Builds and executes requests for operations under \nodes
    /// </summary>
    public class NodesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.nodes.item collection</summary>
        /// <param name="position">The identifier of the node to retrieve.</param>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.NodesItemRequestBuilder"/></returns>
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.NodesItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.NodesItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NodesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nodes{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NodesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nodes{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieves a collection of nodes.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeCollectionResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeCollectionResponseDocument?> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeCollectionResponseDocument> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeCollectionResponseDocument>(requestInfo, OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeCollectionResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderHeadQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Creates a new node.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodePrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 403 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodePrimaryResponseDocument?> PostAsync(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNodeRequestDocument body, Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodePrimaryResponseDocument> PostAsync(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNodeRequestDocument body, Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "403", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "422", OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodePrimaryResponseDocument>(requestInfo, OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodePrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves a collection of nodes.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            return requestInfo;
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderHeadQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Creates a new node.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNodeRequestDocument body, Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNodeRequestDocument body, Action<RequestConfiguration<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder.NodesRequestBuilderPostQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder WithUrl(string rawUrl)
        {
            return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.NodesRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieves a collection of nodes.
        /// </summary>
        public class NodesRequestBuilderGetQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("query")]
            public string? Query { get; set; }
#nullable restore
#else
            [QueryParameter("query")]
            public string Query { get; set; }
#endif
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        public class NodesRequestBuilderHeadQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("query")]
            public string? Query { get; set; }
#nullable restore
#else
            [QueryParameter("query")]
            public string Query { get; set; }
#endif
        }
        /// <summary>
        /// Creates a new node.
        /// </summary>
        public class NodesRequestBuilderPostQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("query")]
            public string? Query { get; set; }
#nullable restore
#else
            [QueryParameter("query")]
            public string Query { get; set; }
#endif
        }
    }
}
