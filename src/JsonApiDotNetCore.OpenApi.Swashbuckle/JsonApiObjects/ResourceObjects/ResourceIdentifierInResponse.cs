using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

// ReSharper disable once UnusedTypeParameter
internal sealed class ResourceIdentifierInResponse<TResource> : IResourceIdentity
    where TResource : IIdentifiable
{
    [Required]
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [Required]
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}