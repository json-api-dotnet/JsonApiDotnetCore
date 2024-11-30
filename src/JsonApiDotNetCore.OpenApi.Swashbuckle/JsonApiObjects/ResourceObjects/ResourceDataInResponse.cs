using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.Links;
using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

internal abstract class ResourceDataInResponse : ResourceData;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
internal sealed class ResourceDataInResponse<TResource> : ResourceDataInResponse
    where TResource : IIdentifiable
{
    [Required]
    [JsonPropertyName("id")]
    public override string Id { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public AttributesInResponse<TResource> Attributes { get; set; } = null!;

    [JsonPropertyName("relationships")]
    public RelationshipsInResponse<TResource> Relationships { get; set; } = null!;

    // Non-required because the related controller may be unavailable when used in an include.
    [JsonPropertyName("links")]
    public ResourceLinks Links { get; set; } = null!;
}
