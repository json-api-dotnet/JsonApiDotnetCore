// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models {
    public class LinksInResourceCollectionDocument : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The describedby property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Describedby {
            get { return BackingStore?.Get<string?>("describedby"); }
            set { BackingStore?.Set("describedby", value); }
        }
#nullable restore
#else
        public string Describedby {
            get { return BackingStore?.Get<string>("describedby"); }
            set { BackingStore?.Set("describedby", value); }
        }
#endif
        /// <summary>The first property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? First {
            get { return BackingStore?.Get<string?>("first"); }
            set { BackingStore?.Set("first", value); }
        }
#nullable restore
#else
        public string First {
            get { return BackingStore?.Get<string>("first"); }
            set { BackingStore?.Set("first", value); }
        }
#endif
        /// <summary>The last property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Last {
            get { return BackingStore?.Get<string?>("last"); }
            set { BackingStore?.Set("last", value); }
        }
#nullable restore
#else
        public string Last {
            get { return BackingStore?.Get<string>("last"); }
            set { BackingStore?.Set("last", value); }
        }
#endif
        /// <summary>The next property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Next {
            get { return BackingStore?.Get<string?>("next"); }
            set { BackingStore?.Set("next", value); }
        }
#nullable restore
#else
        public string Next {
            get { return BackingStore?.Get<string>("next"); }
            set { BackingStore?.Set("next", value); }
        }
#endif
        /// <summary>The prev property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Prev {
            get { return BackingStore?.Get<string?>("prev"); }
            set { BackingStore?.Set("prev", value); }
        }
#nullable restore
#else
        public string Prev {
            get { return BackingStore?.Get<string>("prev"); }
            set { BackingStore?.Set("prev", value); }
        }
#endif
        /// <summary>The self property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Self {
            get { return BackingStore?.Get<string?>("self"); }
            set { BackingStore?.Set("self", value); }
        }
#nullable restore
#else
        public string Self {
            get { return BackingStore?.Get<string>("self"); }
            set { BackingStore?.Set("self", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new linksInResourceCollectionDocument and sets the default values.
        /// </summary>
        public LinksInResourceCollectionDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static LinksInResourceCollectionDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LinksInResourceCollectionDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"describedby", n => { Describedby = n.GetStringValue(); } },
                {"first", n => { First = n.GetStringValue(); } },
                {"last", n => { Last = n.GetStringValue(); } },
                {"next", n => { Next = n.GetStringValue(); } },
                {"prev", n => { Prev = n.GetStringValue(); } },
                {"self", n => { Self = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("describedby", Describedby);
            writer.WriteStringValue("first", First);
            writer.WriteStringValue("last", Last);
            writer.WriteStringValue("next", Next);
            writer.WriteStringValue("prev", Prev);
            writer.WriteStringValue("self", Self);
        }
    }
}
