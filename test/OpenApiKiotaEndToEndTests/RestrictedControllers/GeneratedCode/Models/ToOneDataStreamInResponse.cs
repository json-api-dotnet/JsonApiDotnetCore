// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class ToOneDataStreamInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse? Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks? Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse"/> and sets the default values.
        /// </summary>
        public ToOneDataStreamInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse.CreateFromDiscriminatorValue); } },
                { "links", n => { Links = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamIdentifierInResponse>("data", Data);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipLinks>("links", Links);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
