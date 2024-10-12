// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Mentors;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Teaches;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships
{
    /// <summary>
    /// Builds and executes requests for operations under \teachers\{id}\relationships
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class RelationshipsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The mentors property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Mentors.MentorsRequestBuilder Mentors
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Mentors.MentorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The teaches property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Teaches.TeachesRequestBuilder Teaches
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.Teaches.TeachesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/teachers/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/teachers/{id}/relationships", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
