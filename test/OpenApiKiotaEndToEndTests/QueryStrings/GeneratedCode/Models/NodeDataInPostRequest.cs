// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models {
    #pragma warning disable CS1591
    public class NodeDataInPostRequest : IBackedModel, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeAttributesInPostRequest? Attributes {
            get { return BackingStore?.Get<NodeAttributesInPostRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public NodeAttributesInPostRequest Attributes {
            get { return BackingStore?.Get<NodeAttributesInPostRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeRelationshipsInPostRequest? Relationships {
            get { return BackingStore?.Get<NodeRelationshipsInPostRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public NodeRelationshipsInPostRequest Relationships {
            get { return BackingStore?.Get<NodeRelationshipsInPostRequest>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>The type property</summary>
        public NodeResourceType? Type {
            get { return BackingStore?.Get<NodeResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="NodeDataInPostRequest"/> and sets the default values.
        /// </summary>
        public NodeDataInPostRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="NodeDataInPostRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeDataInPostRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeDataInPostRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"attributes", n => { Attributes = n.GetObjectValue<NodeAttributesInPostRequest>(NodeAttributesInPostRequest.CreateFromDiscriminatorValue); } },
                {"relationships", n => { Relationships = n.GetObjectValue<NodeRelationshipsInPostRequest>(NodeRelationshipsInPostRequest.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<NodeResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeAttributesInPostRequest>("attributes", Attributes);
            writer.WriteObjectValue<NodeRelationshipsInPostRequest>("relationships", Relationships);
            writer.WriteEnumValue<NodeResourceType>("type", Type);
        }
    }
}
