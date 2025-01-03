// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Courses;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Enrollments;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Operations;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students;
using OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class AtomicOperationsClient : BaseRequestBuilder
    {
        /// <summary>The courses property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Courses.CoursesRequestBuilder Courses
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Courses.CoursesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The enrollments property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Enrollments.EnrollmentsRequestBuilder Enrollments
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Enrollments.EnrollmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The operations property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Operations.OperationsRequestBuilder Operations
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Operations.OperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The students property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.StudentsRequestBuilder Students
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Students.StudentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The teachers property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.TeachersRequestBuilder Teachers
        {
            get => new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Teachers.TeachersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.AtomicOperationsClient"/> and sets the default values.
        /// </summary>
        /// <param name="backingStore">The backing store to use for the models.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AtomicOperationsClient(IRequestAdapter requestAdapter, IBackingStoreFactory backingStore = default) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "http://localhost";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
            RequestAdapter.EnableBackingStore(backingStore);
        }
    }
}
#pragma warning restore CS0618