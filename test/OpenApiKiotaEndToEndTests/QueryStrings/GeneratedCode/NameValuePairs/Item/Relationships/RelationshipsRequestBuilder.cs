// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships.Owner;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships
{
    /// <summary>
    /// Builds and executes requests for operations under \nameValuePairs\{id}\relationships
    /// </summary>
    public class RelationshipsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The owner property</summary>
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships.Owner.OwnerRequestBuilder Owner
        {
            get => new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships.Owner.OwnerRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nameValuePairs/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.NameValuePairs.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nameValuePairs/{id}/relationships", rawUrl)
        {
        }
    }
}
