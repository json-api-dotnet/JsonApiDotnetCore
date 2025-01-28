using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

internal abstract class RelationshipsInCreateResourceRequest;

// ReSharper disable once UnusedTypeParameter
internal sealed class RelationshipsInCreateResourceRequest<TResource> : RelationshipsInCreateResourceRequest
    where TResource : IIdentifiable;
