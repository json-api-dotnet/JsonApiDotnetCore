// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class PersonAssignedTodoItemsRelationshipIdentifier : IBackedModel, IParsable
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
        /// <summary>The relationship property</summary>
        public OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipName? Relationship
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipName?>("relationship"); }
            set { BackingStore?.Set("relationship", value); }
        }
        /// <summary>The type property</summary>
        public OpenApiKiotaClientExample.GeneratedCode.Models.PersonResourceType? Type
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.PersonResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipIdentifier"/> and sets the default values.
        /// </summary>
        public PersonAssignedTodoItemsRelationshipIdentifier()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipIdentifier"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipIdentifier CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipIdentifier();
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
                { "relationship", n => { Relationship = n.GetEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipName>(); } },
                { "type", n => { Type = n.GetEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonResourceType>(); } },
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
            writer.WriteEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonAssignedTodoItemsRelationshipName>("relationship", Relationship);
            writer.WriteEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.PersonResourceType>("type", Type);
        }
    }
}
