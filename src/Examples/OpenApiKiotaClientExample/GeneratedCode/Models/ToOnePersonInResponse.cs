// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models {
    public class ToOnePersonInResponse : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PersonIdentifier? Data {
            get { return BackingStore?.Get<PersonIdentifier?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public PersonIdentifier Data {
            get { return BackingStore?.Get<PersonIdentifier>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public LinksInRelationship? Links {
            get { return BackingStore?.Get<LinksInRelationship?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public LinksInRelationship Links {
            get { return BackingStore?.Get<LinksInRelationship>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ToOnePersonInResponse_meta? Meta {
            get { return BackingStore?.Get<ToOnePersonInResponse_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public ToOnePersonInResponse_meta Meta {
            get { return BackingStore?.Get<ToOnePersonInResponse_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new toOnePersonInResponse and sets the default values.
        /// </summary>
        public ToOnePersonInResponse() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ToOnePersonInResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ToOnePersonInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<PersonIdentifier>(PersonIdentifier.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<LinksInRelationship>(LinksInRelationship.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<ToOnePersonInResponse_meta>(ToOnePersonInResponse_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<PersonIdentifier>("data", Data);
            writer.WriteObjectValue<LinksInRelationship>("links", Links);
            writer.WriteObjectValue<ToOnePersonInResponse_meta>("meta", Meta);
        }
    }
}
