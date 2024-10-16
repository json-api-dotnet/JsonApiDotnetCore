// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class AttributesInCreateEnrollmentRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The enrolledAt property</summary>
        public Date? EnrolledAt
        {
            get { return BackingStore?.Get<Date?>("enrolledAt"); }
            set { BackingStore?.Set("enrolledAt", value); }
        }
        /// <summary>The graduatedAt property</summary>
        public Date? GraduatedAt
        {
            get { return BackingStore?.Get<Date?>("graduatedAt"); }
            set { BackingStore?.Set("graduatedAt", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AttributesInCreateEnrollmentRequest"/> and sets the default values.
        /// </summary>
        public AttributesInCreateEnrollmentRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AttributesInCreateEnrollmentRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AttributesInCreateEnrollmentRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AttributesInCreateEnrollmentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "enrolledAt", n => { EnrolledAt = n.GetDateValue(); } },
                { "graduatedAt", n => { GraduatedAt = n.GetDateValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateValue("enrolledAt", EnrolledAt);
            writer.WriteDateValue("graduatedAt", GraduatedAt);
        }
    }
}
#pragma warning restore CS0618
