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
    public partial class TodoItemAttributesInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The createdAt property</summary>
        public DateTimeOffset? CreatedAt
        {
            get { return BackingStore?.Get<DateTimeOffset?>("createdAt"); }
            set { BackingStore?.Set("createdAt", value); }
        }
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description
        {
            get { return BackingStore?.Get<string?>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#nullable restore
#else
        public string Description
        {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#endif
        /// <summary>The durationInHours property</summary>
        public long? DurationInHours
        {
            get { return BackingStore?.Get<long?>("durationInHours"); }
            set { BackingStore?.Set("durationInHours", value); }
        }
        /// <summary>The modifiedAt property</summary>
        public DateTimeOffset? ModifiedAt
        {
            get { return BackingStore?.Get<DateTimeOffset?>("modifiedAt"); }
            set { BackingStore?.Set("modifiedAt", value); }
        }
        /// <summary>The priority property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority? Priority
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority?>("priority"); }
            set { BackingStore?.Set("priority", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemAttributesInResponse"/> and sets the default values.
        /// </summary>
        public TodoItemAttributesInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemAttributesInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemAttributesInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemAttributesInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "createdAt", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "durationInHours", n => { DurationInHours = n.GetLongValue(); } },
                { "modifiedAt", n => { ModifiedAt = n.GetDateTimeOffsetValue(); } },
                { "priority", n => { Priority = n.GetEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("createdAt", CreatedAt);
            writer.WriteStringValue("description", Description);
            writer.WriteLongValue("durationInHours", DurationInHours);
            writer.WriteDateTimeOffsetValue("modifiedAt", ModifiedAt);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority>("priority", Priority);
        }
    }
}
#pragma warning restore CS0618
