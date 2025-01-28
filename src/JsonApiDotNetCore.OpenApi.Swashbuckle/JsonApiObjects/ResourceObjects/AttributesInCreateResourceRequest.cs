using JsonApiDotNetCore.Resources;

namespace JsonApiDotNetCore.OpenApi.Swashbuckle.JsonApiObjects.ResourceObjects;

internal abstract class AttributesInCreateResourceRequest;

// ReSharper disable once UnusedTypeParameter
internal sealed class AttributesInCreateResourceRequest<TResource> : AttributesInCreateResourceRequest
    where TResource : IIdentifiable;
