// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataStreamSecondaryResponseDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse? Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The included property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse>? Included
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse>?>("included"); }
            set { BackingStore?.Set("included", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse> Included
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse>>("included"); }
            set { BackingStore?.Set("included", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamSecondaryResponseDocument"/> and sets the default values.
        /// </summary>
        public DataStreamSecondaryResponseDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamSecondaryResponseDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamSecondaryResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamSecondaryResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse.CreateFromDiscriminatorValue); } },
                { "included", n => { Included = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse.CreateFromDiscriminatorValue)?.AsList(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataStreamDataInResponse>("data", Data);
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInResponse>("included", Included);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceTopLevelLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
#pragma warning restore CS0618
