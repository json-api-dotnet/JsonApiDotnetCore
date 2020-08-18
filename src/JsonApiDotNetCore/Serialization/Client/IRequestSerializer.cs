using System.Collections.Generic;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDotNetCore.Serialization.Client
{
    /// <summary>
    /// Interface for client serializer that can be used to register with the DI, for usage in
    /// custom services or repositories.
    /// </summary>
    public interface IRequestSerializer
    {
        /// <summary>
        /// Creates and serializes a document for a single resource.
        /// </summary>
        /// <returns>The serialized content</returns>
        string Serialize(IIdentifiable resource);

        /// <summary>
        /// Creates and serializes a document for a collection of resources.
        /// </summary>
        /// <returns>The serialized content</returns>
        string Serialize(IReadOnlyCollection<IIdentifiable> resources);

        /// <summary>
        /// Sets the attributes that will be included in the serialized payload.
        /// You can use <see cref="IResourceGraph.GetAttributes{TResource}"/>
        /// to conveniently access the desired <see cref="AttrAttribute"/> instances.
        /// </summary>
        public IReadOnlyCollection<AttrAttribute> AttributesToSerialize { set; }

        /// <summary>
        /// Sets the relationships that will be included in the serialized payload.
        /// You can use <see cref="IResourceGraph.GetRelationships"/>
        /// to conveniently access the desired <see cref="RelationshipAttribute"/> instances.
        /// </summary>
        public IReadOnlyCollection<RelationshipAttribute> RelationshipsToSerialize { set; }
    }
}
