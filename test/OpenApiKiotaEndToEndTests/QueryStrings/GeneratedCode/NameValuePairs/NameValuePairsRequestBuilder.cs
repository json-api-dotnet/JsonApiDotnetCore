// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs
{
    /// <summary>
    /// Builds and executes requests for operations under \nameValuePairs
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class NameValuePairsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.nameValuePairs.item collection</summary>
        /// <param name="position">The identifier of the nameValuePair to retrieve.</param>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.NameValuePairsItemRequestBuilder"/></returns>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.NameValuePairsItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.NameValuePairsItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NameValuePairsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nameValuePairs{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NameValuePairsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nameValuePairs{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieves a collection of nameValuePairs.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairCollectionResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairCollectionResponseDocument?> GetAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairCollectionResponseDocument> GetAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairCollectionResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairCollectionResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task HeadAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task HeadAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderHeadQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Creates a new nameValuePair.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairPrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 403 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairPrimaryResponseDocument?> PostAsync(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNameValuePairRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairPrimaryResponseDocument> PostAsync(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNameValuePairRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "403", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "422", global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairPrimaryResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves a collection of nameValuePairs.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderHeadQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Creates a new nameValuePair.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNameValuePairRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.CreateNameValuePairRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder.NameValuePairsRequestBuilderPostQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.NameValuePairsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieves a collection of nameValuePairs.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class NameValuePairsRequestBuilderGetQueryParameters 
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
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class NameValuePairsRequestBuilderHeadQueryParameters 
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
        /// Creates a new nameValuePair.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class NameValuePairsRequestBuilderPostQueryParameters 
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
#pragma warning restore CS0618
