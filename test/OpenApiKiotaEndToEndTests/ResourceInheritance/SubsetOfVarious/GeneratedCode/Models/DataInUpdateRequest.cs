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
namespace OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInUpdateRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>The type property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.ResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.ResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateRequest"/> and sets the default values.
        /// </summary>
        public DataInUpdateRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("type")?.GetStringValue();
            return mappingValue switch
            {
                "buildings" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateBuildingRequest(),
                "familyHomes" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateFamilyHomeRequest(),
                "mansions" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateMansionRequest(),
                "residences" => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateResidenceRequest(),
                _ => new global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.DataInUpdateRequest(),
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
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.ResourceType>(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.SubsetOfVarious.GeneratedCode.Models.ResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
