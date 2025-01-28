using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

internal abstract class AttributesInUpdateResourceRequest;

// ReSharper disable once UnusedTypeParameter
internal sealed class AttributesInUpdateResourceRequest<TResource> : AttributesInUpdateResourceRequest
    where TResource : IIdentifiable;
