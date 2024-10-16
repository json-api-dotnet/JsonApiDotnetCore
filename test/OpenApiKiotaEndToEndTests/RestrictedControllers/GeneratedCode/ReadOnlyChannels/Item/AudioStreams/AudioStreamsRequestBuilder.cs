// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams
{
    /// <summary>
    /// Builds and executes requests for operations under \readOnlyChannels\{id}\audioStreams
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class AudioStreamsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AudioStreamsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/readOnlyChannels/{id}/audioStreams{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AudioStreamsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/readOnlyChannels/{id}/audioStreams{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieves the related dataStreams of an individual readOnlyChannel&apos;s audioStreams relationship.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamCollectionResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamCollectionResponseDocument?> GetAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamCollectionResponseDocument> GetAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamCollectionResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamCollectionResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task HeadAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task HeadAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderHeadQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves the related dataStreams of an individual readOnlyChannel&apos;s audioStreams relationship.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder.AudioStreamsRequestBuilderHeadQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.ReadOnlyChannels.Item.AudioStreams.AudioStreamsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieves the related dataStreams of an individual readOnlyChannel&apos;s audioStreams relationship.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class AudioStreamsRequestBuilderGetQueryParameters 
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
        public partial class AudioStreamsRequestBuilderHeadQueryParameters 
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
