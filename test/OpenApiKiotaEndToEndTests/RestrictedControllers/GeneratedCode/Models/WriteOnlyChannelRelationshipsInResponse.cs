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
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class WriteOnlyChannelRelationshipsInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The audioStreams property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse? AudioStreams
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse?>("audioStreams"); }
            set { BackingStore?.Set("audioStreams", value); }
        }

        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The ultraHighDefinitionVideoStream property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse? UltraHighDefinitionVideoStream
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse?>("ultraHighDefinitionVideoStream"); }
            set { BackingStore?.Set("ultraHighDefinitionVideoStream", value); }
        }

        /// <summary>The videoStream property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse? VideoStream
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse?>("videoStream"); }
            set { BackingStore?.Set("videoStream", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelRelationshipsInResponse"/> and sets the default values.
        /// </summary>
        public WriteOnlyChannelRelationshipsInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelRelationshipsInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelRelationshipsInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelRelationshipsInResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "audioStreams", n => { AudioStreams = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse.CreateFromDiscriminatorValue); } },
                { "ultraHighDefinitionVideoStream", n => { UltraHighDefinitionVideoStream = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse.CreateFromDiscriminatorValue); } },
                { "videoStream", n => { VideoStream = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse>("audioStreams", AudioStreams);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse>("ultraHighDefinitionVideoStream", UltraHighDefinitionVideoStream);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse>("videoStream", VideoStream);
        }
    }
}
#pragma warning restore CS0618

