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
    public partial class OperationsResponseDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The atomicResults property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult>? AtomicResults
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult>?>("atomic:results"); }
            set { BackingStore?.Set("atomic:results", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult> AtomicResults
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult>>("atomic:results"); }
            set { BackingStore?.Set("atomic:results", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
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
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.OperationsResponseDocument"/> and sets the default values.
        /// </summary>
        public OperationsResponseDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.OperationsResponseDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.OperationsResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.OperationsResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "atomic:results", n => { AtomicResults = n.GetCollectionOfObjectValues<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult>(global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult.CreateFromDiscriminatorValue)?.AsList(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks>(global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>(global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicResult>("atomic:results", AtomicResults);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceTopLevelLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
#pragma warning restore CS0618
