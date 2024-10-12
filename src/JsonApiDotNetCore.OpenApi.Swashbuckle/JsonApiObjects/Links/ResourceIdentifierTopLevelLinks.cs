using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.Links;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
internal sealed class ResourceIdentifierTopLevelLinks
{
    [JsonPropertyName("self")]
    public string Self { get; set; } = null!;

    [JsonPropertyName("related")]
    public string Related { get; set; } = null!;

    [JsonPropertyName("describedby")]
    public string Describedby { get; set; } = null!;
}
