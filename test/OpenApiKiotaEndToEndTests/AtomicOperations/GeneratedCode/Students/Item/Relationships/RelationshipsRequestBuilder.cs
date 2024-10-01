// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Enrollments;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Mentor;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships
{
    /// <summary>
    /// Builds and executes requests for operations under \students\{id}\relationships
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class RelationshipsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The enrollments property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Enrollments.EnrollmentsRequestBuilder Enrollments
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Enrollments.EnrollmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The mentor property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Mentor.MentorRequestBuilder Mentor
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.Mentor.MentorRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/students/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/students/{id}/relationships", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
