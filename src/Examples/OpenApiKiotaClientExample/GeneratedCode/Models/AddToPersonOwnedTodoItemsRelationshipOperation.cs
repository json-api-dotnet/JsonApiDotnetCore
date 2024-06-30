// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class AddToPersonOwnedTodoItemsRelationshipOperation : OpenApiKiotaClientExample.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>? Data
        {
            get { return BackingStore?.Get<List<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest> Data
        {
            get { return BackingStore?.Get<List<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The op property</summary>
        public OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode? Op
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }
        /// <summary>The ref property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier? Ref
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier?>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#nullable restore
#else
        public OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier Ref
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.AddToPersonOwnedTodoItemsRelationshipOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OpenApiKiotaClientExample.GeneratedCode.Models.AddToPersonOwnedTodoItemsRelationshipOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaClientExample.GeneratedCode.Models.AddToPersonOwnedTodoItemsRelationshipOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>(OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                { "op", n => { Op = n.GetEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode>(); } },
                { "ref", n => { Ref = n.GetObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>(OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>("data", Data);
            writer.WriteEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode>("op", Op);
            writer.WriteObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>("ref", Ref);
        }
    }
}
