// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class ToManyCourseInRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest>? Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest> Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyCourseInRequest"/> and sets the default values.
        /// </summary>
        public ToManyCourseInRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyCourseInRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyCourseInRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.ToManyCourseInRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest>(global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseIdentifierInRequest>("data", Data);
        }
    }
}
#pragma warning restore CS0618
