// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class OperationsRequestDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The atomicOperations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation>? AtomicOperations
        {
            get { return BackingStore?.Get<List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation>?>("atomic:operations"); }
            set { BackingStore?.Set("atomic:operations", value); }
        }
#nullable restore
#else
        public List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation> AtomicOperations
        {
            get { return BackingStore?.Get<List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation>>("atomic:operations"); }
            set { BackingStore?.Set("atomic:operations", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.OperationsRequestDocument"/> and sets the default values.
        /// </summary>
        public OperationsRequestDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.OperationsRequestDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.OperationsRequestDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.OperationsRequestDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "atomic:operations", n => { AtomicOperations = n.GetCollectionOfObjectValues<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation>(OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation.CreateFromDiscriminatorValue)?.ToList(); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta>(OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation>("atomic:operations", AtomicOperations);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}