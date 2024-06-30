// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class DataInCreateNameValuePairRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest? Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest? Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>The type property</summary>
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairResourceType? Type
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInCreateNameValuePairRequest"/> and sets the default values.
        /// </summary>
        public DataInCreateNameValuePairRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInCreateNameValuePairRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInCreateNameValuePairRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInCreateNameValuePairRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest.CreateFromDiscriminatorValue); } },
                { "relationships", n => { Relationships = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInCreateNameValuePairRequest>("attributes", Attributes);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNameValuePairRequest>("relationships", Relationships);
            writer.WriteEnumValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairResourceType>("type", Type);
        }
    }
}
