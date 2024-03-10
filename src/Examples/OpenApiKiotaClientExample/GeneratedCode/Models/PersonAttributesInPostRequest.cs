// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models {
    public class PersonAttributesInPostRequest : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The firstName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FirstName {
            get { return BackingStore?.Get<string?>("firstName"); }
            set { BackingStore?.Set("firstName", value); }
        }
#nullable restore
#else
        public string FirstName {
            get { return BackingStore?.Get<string>("firstName"); }
            set { BackingStore?.Set("firstName", value); }
        }
#endif
        /// <summary>The lastName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LastName {
            get { return BackingStore?.Get<string?>("lastName"); }
            set { BackingStore?.Set("lastName", value); }
        }
#nullable restore
#else
        public string LastName {
            get { return BackingStore?.Get<string>("lastName"); }
            set { BackingStore?.Set("lastName", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new personAttributesInPostRequest and sets the default values.
        /// </summary>
        public PersonAttributesInPostRequest() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PersonAttributesInPostRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PersonAttributesInPostRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"firstName", n => { FirstName = n.GetStringValue(); } },
                {"lastName", n => { LastName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("firstName", FirstName);
            writer.WriteStringValue("lastName", LastName);
        }
    }
}
