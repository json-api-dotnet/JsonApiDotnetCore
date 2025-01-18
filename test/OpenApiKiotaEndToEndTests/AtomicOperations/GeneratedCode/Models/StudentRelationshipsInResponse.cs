// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class StudentRelationshipsInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The enrollments property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyEnrollmentInResponse? Enrollments
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyEnrollmentInResponse?>("enrollments"); }
            set { BackingStore?.Set("enrollments", value); }
        }

        /// <summary>The mentor property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.NullableToOneTeacherInResponse? Mentor
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.NullableToOneTeacherInResponse?>("mentor"); }
            set { BackingStore?.Set("mentor", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentRelationshipsInResponse"/> and sets the default values.
        /// </summary>
        public StudentRelationshipsInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentRelationshipsInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentRelationshipsInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentRelationshipsInResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "enrollments", n => { Enrollments = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyEnrollmentInResponse>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyEnrollmentInResponse.CreateFromDiscriminatorValue); } },
                { "mentor", n => { Mentor = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.NullableToOneTeacherInResponse>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.NullableToOneTeacherInResponse.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyEnrollmentInResponse>("enrollments", Enrollments);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.NullableToOneTeacherInResponse>("mentor", Mentor);
        }
    }
}
#pragma warning restore CS0618

