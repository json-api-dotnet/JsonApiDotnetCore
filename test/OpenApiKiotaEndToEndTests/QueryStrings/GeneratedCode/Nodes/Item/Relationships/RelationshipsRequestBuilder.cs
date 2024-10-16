// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Children;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Parent;
using OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Values;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships
{
    /// <summary>
    /// Builds and executes requests for operations under \nodes\{id}\relationships
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class RelationshipsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The children property</summary>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Children.ChildrenRequestBuilder Children
        {
            get => new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Children.ChildrenRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The parent property</summary>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Parent.ParentRequestBuilder Parent
        {
            get => new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Parent.ParentRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The values property</summary>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Values.ValuesRequestBuilder Values
        {
            get => new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.Values.ValuesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nodes/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Nodes.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/nodes/{id}/relationships", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
