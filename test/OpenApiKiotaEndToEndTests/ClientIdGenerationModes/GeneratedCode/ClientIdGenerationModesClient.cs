// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Games;
using OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.PlayerGroups;
using OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Players;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ClientIdGenerationModesClient : BaseRequestBuilder
    {
        /// <summary>The games property</summary>
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Games.GamesRequestBuilder Games
        {
            get => new global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Games.GamesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The playerGroups property</summary>
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.PlayerGroups.PlayerGroupsRequestBuilder PlayerGroups
        {
            get => new global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.PlayerGroups.PlayerGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The players property</summary>
        public global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Players.PlayersRequestBuilder Players
        {
            get => new global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Players.PlayersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.ClientIdGenerationModesClient"/> and sets the default values.
        /// </summary>
        /// <param name="backingStore">The backing store to use for the models.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ClientIdGenerationModesClient(IRequestAdapter requestAdapter, IBackingStoreFactory backingStore = default) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "http://localhost";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
            RequestAdapter.EnableBackingStore(backingStore);
        }
    }
}
#pragma warning restore CS0618
