// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class UpdateEnrollmentStudentRelationshipOperation : global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest? Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The op property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateOperationCode? Op
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }
        /// <summary>The ref property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier? Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier?>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateEnrollmentStudentRelationshipOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateEnrollmentStudentRelationshipOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateEnrollmentStudentRelationshipOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest.CreateFromDiscriminatorValue); } },
                { "op", n => { Op = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateOperationCode>(); } },
                { "ref", n => { Ref = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentIdentifierInRequest>("data", Data);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.UpdateOperationCode>("op", Op);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentStudentRelationshipIdentifier>("ref", Ref);
        }
    }
}
#pragma warning restore CS0618
