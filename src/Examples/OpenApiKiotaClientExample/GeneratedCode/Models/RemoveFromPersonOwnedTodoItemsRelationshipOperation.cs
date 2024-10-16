// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class RemoveFromPersonOwnedTodoItemsRelationshipOperation : global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>? Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest> Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The op property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveOperationCode? Op
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }
        /// <summary>The ref property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier? Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier?>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier Ref
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveFromPersonOwnedTodoItemsRelationshipOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveFromPersonOwnedTodoItemsRelationshipOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveFromPersonOwnedTodoItemsRelationshipOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest.CreateFromDiscriminatorValue)?.AsList(); } },
                { "op", n => { Op = n.GetEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveOperationCode>(); } },
                { "ref", n => { Ref = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>(global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemIdentifierInRequest>("data", Data);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RemoveOperationCode>("op", Op);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.PersonOwnedTodoItemsRelationshipIdentifier>("ref", Ref);
        }
    }
}
#pragma warning restore CS0618
