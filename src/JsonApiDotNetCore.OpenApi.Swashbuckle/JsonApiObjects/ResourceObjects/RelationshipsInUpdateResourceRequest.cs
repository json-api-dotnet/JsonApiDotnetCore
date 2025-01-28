using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

internal abstract class RelationshipsInUpdateResourceRequest;

// ReSharper disable once UnusedTypeParameter
internal sealed class RelationshipsInUpdateResourceRequest<TResource> : RelationshipsInUpdateResourceRequest
    where TResource : IIdentifiable;
