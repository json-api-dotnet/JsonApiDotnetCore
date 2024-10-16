// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.AudioStreams;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.UltraHighDefinitionVideoStream;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.VideoStream;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships
{
    /// <summary>
    /// Builds and executes requests for operations under \writeOnlyChannels\{id}\relationships
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class RelationshipsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The audioStreams property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.AudioStreams.AudioStreamsRequestBuilder AudioStreams
        {
            get => new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.AudioStreams.AudioStreamsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The ultraHighDefinitionVideoStream property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.UltraHighDefinitionVideoStream.UltraHighDefinitionVideoStreamRequestBuilder UltraHighDefinitionVideoStream
        {
            get => new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.UltraHighDefinitionVideoStream.UltraHighDefinitionVideoStreamRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The videoStream property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.VideoStream.VideoStreamRequestBuilder VideoStream
        {
            get => new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.VideoStream.VideoStreamRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels/{id}/relationships", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.Relationships.RelationshipsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RelationshipsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels/{id}/relationships", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
