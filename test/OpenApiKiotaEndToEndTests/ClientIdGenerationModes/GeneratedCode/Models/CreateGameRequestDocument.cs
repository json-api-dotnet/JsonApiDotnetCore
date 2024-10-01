// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class CreateGameRequestDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest? Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.CreateGameRequestDocument"/> and sets the default values.
        /// </summary>
        public CreateGameRequestDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.CreateGameRequestDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.CreateGameRequestDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.CreateGameRequestDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest>(global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInCreateGameRequest>("data", Data);
        }
    }
}
#pragma warning restore CS0618
