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
    public partial class RelationshipsInUpdateTodoItemRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The assignee property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.NullableToOnePersonInRequest? Assignee
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.NullableToOnePersonInRequest?>("assignee"); }
            set { BackingStore?.Set("assignee", value); }
        }

        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The owner property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.ToOnePersonInRequest? Owner
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToOnePersonInRequest?>("owner"); }
            set { BackingStore?.Set("owner", value); }
        }

        /// <summary>The tags property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.ToManyTagInRequest? Tags
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToManyTagInRequest?>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTodoItemRequest"/> and sets the default values.
        /// </summary>
        public RelationshipsInUpdateTodoItemRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTodoItemRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTodoItemRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTodoItemRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "assignee", n => { Assignee = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.NullableToOnePersonInRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.NullableToOnePersonInRequest.CreateFromDiscriminatorValue); } },
                { "owner", n => { Owner = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToOnePersonInRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.ToOnePersonInRequest.CreateFromDiscriminatorValue); } },
                { "tags", n => { Tags = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToManyTagInRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.ToManyTagInRequest.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.NullableToOnePersonInRequest>("assignee", Assignee);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToOnePersonInRequest>("owner", Owner);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.ToManyTagInRequest>("tags", Tags);
        }
    }
}
#pragma warning restore CS0618

