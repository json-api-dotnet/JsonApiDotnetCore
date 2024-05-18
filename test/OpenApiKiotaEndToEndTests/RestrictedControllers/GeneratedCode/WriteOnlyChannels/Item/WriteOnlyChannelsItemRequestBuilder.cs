// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item {
    /// <summary>
    /// Builds and executes requests for operations under \writeOnlyChannels\{id}
    /// </summary>
    public class WriteOnlyChannelsItemRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>The relationships property</summary>
        public RelationshipsRequestBuilder Relationships
        {
            get => new RelationshipsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="WriteOnlyChannelsItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WriteOnlyChannelsItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels/{id}{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="WriteOnlyChannelsItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WriteOnlyChannelsItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels/{id}{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Deletes an existing writeOnlyChannel by its identifier.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ErrorResponseDocument">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"404", ErrorResponseDocument.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Updates an existing writeOnlyChannel.
        /// </summary>
        /// <returns>A <see cref="WriteOnlyChannelPrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="ErrorResponseDocument">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WriteOnlyChannelPrimaryResponseDocument?> PatchAsync(WriteOnlyChannelPatchRequestDocument body, Action<RequestConfiguration<WriteOnlyChannelsItemRequestBuilderPatchQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<WriteOnlyChannelPrimaryResponseDocument> PatchAsync(WriteOnlyChannelPatchRequestDocument body, Action<RequestConfiguration<WriteOnlyChannelsItemRequestBuilderPatchQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"400", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"404", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"409", ErrorResponseDocument.CreateFromDiscriminatorValue},
                {"422", ErrorResponseDocument.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WriteOnlyChannelPrimaryResponseDocument>(requestInfo, WriteOnlyChannelPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Deletes an existing writeOnlyChannel by its identifier.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            return requestInfo;
        }
        /// <summary>
        /// Updates an existing writeOnlyChannel.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(WriteOnlyChannelPatchRequestDocument body, Action<RequestConfiguration<WriteOnlyChannelsItemRequestBuilderPatchQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(WriteOnlyChannelPatchRequestDocument body, Action<RequestConfiguration<WriteOnlyChannelsItemRequestBuilderPatchQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="WriteOnlyChannelsItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public WriteOnlyChannelsItemRequestBuilder WithUrl(string rawUrl)
        {
            return new WriteOnlyChannelsItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Updates an existing writeOnlyChannel.
        /// </summary>
        public class WriteOnlyChannelsItemRequestBuilderPatchQueryParameters 
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
