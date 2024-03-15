// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.PlayerGroups {
    /// <summary>
    /// Builds and executes requests for operations under \playerGroups
    /// </summary>
    public class PlayerGroupsRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new PlayerGroupsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PlayerGroupsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/playerGroups{?query*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new PlayerGroupsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PlayerGroupsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/playerGroups{?query*}", rawUrl) {
        }
        /// <summary>
        /// Creates a new playerGroup.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<PlayerGroupPrimaryResponseDocument?> PostAsync(PlayerGroupPostRequestDocument body, Action<RequestConfiguration<PlayerGroupsRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<PlayerGroupPrimaryResponseDocument> PostAsync(PlayerGroupPostRequestDocument body, Action<RequestConfiguration<PlayerGroupsRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"403", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"409", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"422", ErrorResponseDocument.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<PlayerGroupPrimaryResponseDocument>(requestInfo, PlayerGroupPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Creates a new playerGroup.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(PlayerGroupPostRequestDocument body, Action<RequestConfiguration<PlayerGroupsRequestBuilderPostQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(PlayerGroupPostRequestDocument body, Action<RequestConfiguration<PlayerGroupsRequestBuilderPostQueryParameters>> requestConfiguration = default) {
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
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public PlayerGroupsRequestBuilder WithUrl(string rawUrl) {
            return new PlayerGroupsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Creates a new playerGroup.
        /// </summary>
        public class PlayerGroupsRequestBuilderPostQueryParameters {
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