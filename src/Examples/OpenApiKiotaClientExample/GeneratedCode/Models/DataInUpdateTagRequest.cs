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
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInUpdateTagRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The id property</summary>
        public string? Id
        {
            get { return BackingStore?.Get<string?>("id"); }
            set { BackingStore?.Set("id", value); }
        }

        /// <summary>The lid property</summary>
        public string? Lid
        {
            get { return BackingStore?.Get<string?>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>The relationships property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest? Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }

        /// <summary>The type property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest"/> and sets the default values.
        /// </summary>
        public DataInUpdateTagRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetStringValue(); } },
                { "lid", n => { Lid = n.GetStringValue(); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>(global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
                { "relationships", n => { Relationships = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest>("attributes", Attributes);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("lid", Lid);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest>("relationships", Relationships);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618

