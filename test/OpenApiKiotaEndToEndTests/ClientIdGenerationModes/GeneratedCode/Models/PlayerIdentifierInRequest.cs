// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class PlayerIdentifierInRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The id property</summary>
        public Guid? Id
        {
            get { return BackingStore?.Get<Guid?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The type property</summary>
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerIdentifierInRequest"/> and sets the default values.
        /// </summary>
        public PlayerIdentifierInRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerIdentifierInRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerIdentifierInRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerIdentifierInRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "id", n => { Id = n.GetGuidValue(); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteGuidValue("id", Id);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.PlayerResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
