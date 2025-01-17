// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item;
using OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries
{
    /// <summary>
    /// Builds and executes requests for operations under \countries
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class CountriesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the OpenApiKiotaEndToEndTests.Headers.GeneratedCode.countries.item collection</summary>
        /// <param name="position">The identifier of the country to retrieve.</param>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.CountriesItemRequestBuilder"/></returns>
        public global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.CountriesItemRequestBuilder this[Guid position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.CountriesItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CountriesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/countries{?query*}", pathParameters)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CountriesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/countries{?query*}", rawUrl)
        {
        }

        /// <summary>
        /// Retrieves a collection of countries.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryCollectionResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        public async Task<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryCollectionResponseDocument?> GetAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryCollectionResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryCollectionResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        public async Task HeadAsync(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new country.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryPrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 403 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 422 status code</exception>
        public async Task<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryPrimaryResponseDocument?> PostAsync(global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CreateCountryRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "403", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "422", global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryPrimaryResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CountryPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a collection of countries.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
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
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }

        /// <summary>
        /// Creates a new country.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.CreateCountryRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder.CountriesRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
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
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder WithUrl(string rawUrl)
        {
            return new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.CountriesRequestBuilder(rawUrl, RequestAdapter);
        }

        /// <summary>
        /// Retrieves a collection of countries.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class CountriesRequestBuilderGetQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
            [QueryParameter("query")]
            public string? Query { get; set; }
        }

        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class CountriesRequestBuilderHeadQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
            [QueryParameter("query")]
            public string? Query { get; set; }
        }

        /// <summary>
        /// Creates a new country.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class CountriesRequestBuilderPostQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
            [QueryParameter("query")]
            public string? Query { get; set; }
        }
    }
}
#pragma warning restore CS0618

