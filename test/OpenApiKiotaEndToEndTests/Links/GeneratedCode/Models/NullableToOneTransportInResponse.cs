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
namespace OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class NullableToOneTransportInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The data property</summary>
        public global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.TransportIdentifierInResponse? Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.TransportIdentifierInResponse?>("data"); }
            set { BackingStore?.Set("data", value); }
        }

        /// <summary>The links property</summary>
        public global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.RelationshipLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.RelationshipLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse"/> and sets the default values.
        /// </summary>
        public NullableToOneTransportInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.TransportIdentifierInResponse>(global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.TransportIdentifierInResponse.CreateFromDiscriminatorValue); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.RelationshipLinks>(global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.RelationshipLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.TransportIdentifierInResponse>("data", Data);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.RelationshipLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
#pragma warning restore CS0618

