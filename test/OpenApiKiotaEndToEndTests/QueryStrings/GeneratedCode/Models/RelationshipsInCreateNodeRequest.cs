// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class RelationshipsInCreateNodeRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The children property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest? Children
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest?>("children"); }
            set { BackingStore?.Set("children", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest Children
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest>("children"); }
            set { BackingStore?.Set("children", value); }
        }
#endif
        /// <summary>The parent property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest? Parent
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest?>("parent"); }
            set { BackingStore?.Set("parent", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest Parent
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest>("parent"); }
            set { BackingStore?.Set("parent", value); }
        }
#endif
        /// <summary>The values property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest? Values
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest?>("values"); }
            set { BackingStore?.Set("values", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest Values
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest>("values"); }
            set { BackingStore?.Set("values", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNodeRequest"/> and sets the default values.
        /// </summary>
        public RelationshipsInCreateNodeRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNodeRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNodeRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInCreateNodeRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "children", n => { Children = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest.CreateFromDiscriminatorValue); } },
                { "parent", n => { Parent = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest.CreateFromDiscriminatorValue); } },
                { "values", n => { Values = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNodeInRequest>("children", Children);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableToOneNodeInRequest>("parent", Parent);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ToManyNameValuePairInRequest>("values", Values);
        }
    }
}
