// <auto-generated/>
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
    public partial class TagIdentifierInRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id
        {
            get { return BackingStore?.Get<string?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#nullable restore
#else
        public string Id
        {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#endif
        /// <summary>The lid property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Lid
        {
            get { return BackingStore?.Get<string?>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }
#nullable restore
#else
        public string Lid
        {
            get { return BackingStore?.Get<string>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>The type property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.TagIdentifierInRequest"/> and sets the default values.
        /// </summary>
        public TagIdentifierInRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.TagIdentifierInRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.TagIdentifierInRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.TagIdentifierInRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "id", n => { Id = n.GetStringValue(); } },
                { "lid", n => { Lid = n.GetStringValue(); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>(global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
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
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("lid", Lid);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
