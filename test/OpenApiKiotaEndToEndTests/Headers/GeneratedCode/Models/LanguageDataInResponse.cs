// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class LanguageDataInResponse : global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.DataInResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>The id property</summary>
        public Guid? Id
        {
            get { return BackingStore?.Get<Guid?>("id"); }
            set { BackingStore?.Set("id", value); }
        }

        /// <summary>The links property</summary>
        public global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse>(global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetGuidValue(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks>(global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse>("attributes", Attributes);
            writer.WriteGuidValue("id", Id);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks>("links", Links);
        }
    }
}
#pragma warning restore CS0618

