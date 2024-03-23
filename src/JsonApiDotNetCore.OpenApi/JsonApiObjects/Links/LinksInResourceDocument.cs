using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JsonApiDotNetCore.OpenApi.JsonApiObjects.Links;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
internal sealed class LinksInResourceDocument
{
    [JsonPropertyName("self")]
    public string Self { get; set; } = null!;

    [JsonPropertyName("describedby")]
    public string Describedby { get; set; } = null!;
}
