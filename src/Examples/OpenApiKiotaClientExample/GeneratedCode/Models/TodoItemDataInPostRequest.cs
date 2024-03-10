// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models {
    public class TodoItemDataInPostRequest : IBackedModel, IParsable {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TodoItemAttributesInPostRequest? Attributes {
            get { return BackingStore?.Get<TodoItemAttributesInPostRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public TodoItemAttributesInPostRequest Attributes {
            get { return BackingStore?.Get<TodoItemAttributesInPostRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TodoItemRelationshipsInPostRequest? Relationships {
            get { return BackingStore?.Get<TodoItemRelationshipsInPostRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public TodoItemRelationshipsInPostRequest Relationships {
            get { return BackingStore?.Get<TodoItemRelationshipsInPostRequest>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>The type property</summary>
        public TodoItemResourceType? Type {
            get { return BackingStore?.Get<TodoItemResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new todoItemDataInPostRequest and sets the default values.
        /// </summary>
        public TodoItemDataInPostRequest() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static TodoItemDataInPostRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TodoItemDataInPostRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attributes", n => { Attributes = n.GetObjectValue<TodoItemAttributesInPostRequest>(TodoItemAttributesInPostRequest.CreateFromDiscriminatorValue); } },
                {"relationships", n => { Relationships = n.GetObjectValue<TodoItemRelationshipsInPostRequest>(TodoItemRelationshipsInPostRequest.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<TodoItemResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<TodoItemAttributesInPostRequest>("attributes", Attributes);
            writer.WriteObjectValue<TodoItemRelationshipsInPostRequest>("relationships", Relationships);
            writer.WriteEnumValue<TodoItemResourceType>("type", Type);
        }
    }
}
