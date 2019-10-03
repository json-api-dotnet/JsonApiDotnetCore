﻿
namespace JsonApiDotNetCore.Serialization.Serializer.Contracts
{
    /// <summary>
    /// Serializer used internally in JsonApiDotNetCore to serialize responses.
    /// </summary>
    public interface IJsonApiSerializer
    {
        /// <summary>
        /// Serializes a single entity or a list of entities.
        /// </summary>
        string Serialize(object content);
    }
}