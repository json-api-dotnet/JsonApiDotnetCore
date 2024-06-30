// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class CreateWriteOnlyChannelRequestDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest? Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument"/> and sets the default values.
        /// </summary>
        public CreateWriteOnlyChannelRequestDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest>("data", Data);
        }
    }
}
