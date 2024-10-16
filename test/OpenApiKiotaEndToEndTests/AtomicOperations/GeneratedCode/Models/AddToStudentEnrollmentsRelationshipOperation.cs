// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class AddToStudentEnrollmentsRelationshipOperation : global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest>? Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest> Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The op property</summary>
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode? Op
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }
        /// <summary>The ref property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier? Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier?>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToStudentEnrollmentsRelationshipOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToStudentEnrollmentsRelationshipOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToStudentEnrollmentsRelationshipOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest.CreateFromDiscriminatorValue)?.AsList(); } },
                { "op", n => { Op = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode>(); } },
                { "ref", n => { Ref = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.EnrollmentIdentifierInRequest>("data", Data);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode>("op", Op);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.StudentEnrollmentsRelationshipIdentifier>("ref", Ref);
        }
    }
}
#pragma warning restore CS0618
