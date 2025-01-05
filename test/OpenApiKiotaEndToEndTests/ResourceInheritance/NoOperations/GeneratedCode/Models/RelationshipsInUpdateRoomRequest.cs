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
namespace OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class RelationshipsInUpdateRoomRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The openapiDiscriminator property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceType? OpenapiDiscriminator
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceType?>("openapi:discriminator"); }
            set { BackingStore?.Set("openapi:discriminator", value); }
        }

        /// <summary>The residence property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ToOneResidenceInRequest? Residence
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ToOneResidenceInRequest?>("residence"); }
            set { BackingStore?.Set("residence", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateRoomRequest"/> and sets the default values.
        /// </summary>
        public RelationshipsInUpdateRoomRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateRoomRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateRoomRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("openapi:discriminator")?.GetStringValue();
            return mappingValue switch
            {
                "bathrooms" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateBathroomRequest(),
                "bedrooms" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateBedroomRequest(),
                "kitchens" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateKitchenRequest(),
                "livingRooms" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateLivingRoomRequest(),
                "toilets" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateToiletRequest(),
                _ => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RelationshipsInUpdateRoomRequest(),
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
                { "openapi:discriminator", n => { OpenapiDiscriminator = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceType>(); } },
                { "residence", n => { Residence = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ToOneResidenceInRequest>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ToOneResidenceInRequest.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceType>("openapi:discriminator", OpenapiDiscriminator);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ToOneResidenceInRequest>("residence", Residence);
        }
    }
}
#pragma warning restore CS0618
