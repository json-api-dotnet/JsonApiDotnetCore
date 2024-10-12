// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class ErrorObject : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The code property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Code
        {
            get { return BackingStore?.Get<string?>("code"); }
            set { BackingStore?.Set("code", value); }
        }
#nullable restore
#else
        public string Code
        {
            get { return BackingStore?.Get<string>("code"); }
            set { BackingStore?.Set("code", value); }
        }
#endif
        /// <summary>The detail property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Detail
        {
            get { return BackingStore?.Get<string?>("detail"); }
            set { BackingStore?.Set("detail", value); }
        }
#nullable restore
#else
        public string Detail
        {
            get { return BackingStore?.Get<string>("detail"); }
            set { BackingStore?.Set("detail", value); }
        }
#endif
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
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>The source property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource? Source
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource?>("source"); }
            set { BackingStore?.Set("source", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource Source
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource>("source"); }
            set { BackingStore?.Set("source", value); }
        }
#endif
        /// <summary>The status property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Status
        {
            get { return BackingStore?.Get<string?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#nullable restore
#else
        public string Status
        {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#endif
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title
        {
            get { return BackingStore?.Get<string?>("title"); }
            set { BackingStore?.Set("title", value); }
        }
#nullable restore
#else
        public string Title
        {
            get { return BackingStore?.Get<string>("title"); }
            set { BackingStore?.Set("title", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorObject"/> and sets the default values.
        /// </summary>
        public ErrorObject()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorObject"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorObject CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorObject();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "code", n => { Code = n.GetStringValue(); } },
                { "detail", n => { Detail = n.GetStringValue(); } },
                { "id", n => { Id = n.GetStringValue(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
                { "source", n => { Source = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource.CreateFromDiscriminatorValue); } },
                { "status", n => { Status = n.GetStringValue(); } },
                { "title", n => { Title = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteStringValue("detail", Detail);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorSource>("source", Source);
            writer.WriteStringValue("status", Status);
            writer.WriteStringValue("title", Title);
        }
    }
}
#pragma warning restore CS0618
