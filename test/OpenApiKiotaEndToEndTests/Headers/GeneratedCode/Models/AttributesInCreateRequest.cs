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
namespace OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class AttributesInCreateRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The openapiDiscriminator property</summary>
        public global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceType? OpenapiDiscriminator
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceType?>("openapi:discriminator"); }
            set { BackingStore?.Set("openapi:discriminator", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.AttributesInCreateRequest"/> and sets the default values.
        /// </summary>
        public AttributesInCreateRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.AttributesInCreateRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.AttributesInCreateRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("openapi:discriminator")?.GetStringValue();
            return mappingValue switch
            {
                "countries" => new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.AttributesInCreateCountryRequest(),
                _ => new global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.AttributesInCreateRequest(),
            };
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "openapi:discriminator", n => { OpenapiDiscriminator = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceType>(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceType>("openapi:discriminator", OpenapiDiscriminator);
        }
    }
}
#pragma warning restore CS0618
