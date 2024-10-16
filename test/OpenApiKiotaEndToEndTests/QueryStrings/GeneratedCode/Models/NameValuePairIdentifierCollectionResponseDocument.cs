// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class NameValuePairIdentifierCollectionResponseDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse>? Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse> Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierCollectionResponseDocument"/> and sets the default values.
        /// </summary>
        public NameValuePairIdentifierCollectionResponseDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierCollectionResponseDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierCollectionResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierCollectionResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse>(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse.CreateFromDiscriminatorValue)?.AsList(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks>(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NameValuePairIdentifierInResponse>("data", Data);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierCollectionTopLevelLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
#pragma warning restore CS0618
