using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using JsonApiDotNetCore.Serialization.Objects;

namespace JsonApiDotNetCore.Serialization.RequestAdapters
{
    /// <inheritdoc cref="IResourceObjectAdapter" />
    public sealed class ResourceObjectAdapter : ResourceIdentityAdapter, IResourceObjectAdapter
    {
        private readonly IJsonApiOptions _options;
        private readonly IRelationshipDataAdapter _relationshipDataAdapter;

        public ResourceObjectAdapter(IResourceGraph resourceGraph, IResourceFactory resourceFactory, IJsonApiOptions options,
            IRelationshipDataAdapter relationshipDataAdapter)
            : base(resourceGraph, resourceFactory)
        {
            ArgumentGuard.NotNull(options, nameof(options));
            ArgumentGuard.NotNull(relationshipDataAdapter, nameof(relationshipDataAdapter));

            _options = options;
            _relationshipDataAdapter = relationshipDataAdapter;
        }

        /// <inheritdoc />
        public (IIdentifiable resource, ResourceContext resourceContext) Convert(ResourceObject resourceObject, ResourceIdentityRequirements requirements,
            RequestAdapterState state)
        {
            ArgumentGuard.NotNull(resourceObject, nameof(resourceObject));
            ArgumentGuard.NotNull(requirements, nameof(requirements));
            ArgumentGuard.NotNull(state, nameof(state));

            (IIdentifiable resource, ResourceContext resourceContext) = ConvertResourceIdentity(resourceObject, requirements, state);

            ConvertAttributes(resourceObject.Attributes, resource, resourceContext, state);
            ConvertRelationships(resourceObject.Relationships, resource, resourceContext, state);

            return (resource, resourceContext);
        }

        private void ConvertAttributes(IDictionary<string, object> resourceObjectAttributes, IIdentifiable resource, ResourceContext resourceContext,
            RequestAdapterState state)
        {
            using IDisposable _ = state.Position.PushElement("attributes");

            foreach ((string attributeName, object attributeValue) in resourceObjectAttributes.EmptyIfNull())
            {
                ConvertAttribute(resource, attributeName, attributeValue, resourceContext, state);
            }
        }

        private void ConvertAttribute(IIdentifiable resource, string attributeName, object attributeValue, ResourceContext resourceContext,
            RequestAdapterState state)
        {
            using IDisposable _ = state.Position.PushElement(attributeName);

            AttrAttribute attr = resourceContext.TryGetAttributeByPublicName(attributeName);

            if (attr == null && _options.AllowUnknownFieldsInRequestBody)
            {
                return;
            }

            AssertIsKnownAttribute(attr, attributeName, resourceContext, state);
            AssertNoInvalidAttribute(attributeValue, state);
            AssertNoBlockedCreate(attr, state);
            AssertNoBlockedChange(attr, state);
            AssertNotReadOnly(attr, state);

            attr.SetValue(resource, attributeValue);
            state.WritableTargetedFields.Attributes.Add(attr);
        }

        [AssertionMethod]
        private static void AssertIsKnownAttribute(AttrAttribute attr, string attributeName, ResourceContext resourceContext, RequestAdapterState state)
        {
            if (attr == null)
            {
                throw new ModelConversionException(state.Position, "Unknown attribute found.",
                    $"Attribute '{attributeName}' does not exist on resource type '{resourceContext.PublicName}'.");
            }
        }

        private static void AssertNoInvalidAttribute(object attributeValue, RequestAdapterState state)
        {
            if (attributeValue is JsonInvalidAttributeInfo info)
            {
                if (info == JsonInvalidAttributeInfo.Id)
                {
                    throw new DeserializationException(state.Position, null, "Resource ID is read-only.");
                }

                string typeName = info.AttributeType.GetFriendlyTypeName();

                throw new DeserializationException(state.Position, null,
                    $"Failed to convert attribute '{info.AttributeName}' with value '{info.JsonValue}' of type '{info.JsonType}' to type '{typeName}'.");
            }
        }

        private static void AssertNoBlockedCreate(AttrAttribute attr, RequestAdapterState state)
        {
            if (state.Request.WriteOperation == WriteOperationKind.CreateResource && !attr.Capabilities.HasFlag(AttrCapabilities.AllowCreate))
            {
                throw new DeserializationException(state.Position, "Setting the initial value of the requested attribute is not allowed.",
                    $"Setting the initial value of '{attr.PublicName}' is not allowed.");
            }
        }

        private static void AssertNoBlockedChange(AttrAttribute attr, RequestAdapterState state)
        {
            if (state.Request.WriteOperation == WriteOperationKind.UpdateResource && !attr.Capabilities.HasFlag(AttrCapabilities.AllowChange))
            {
                throw new DeserializationException(state.Position, "Changing the value of the requested attribute is not allowed.",
                    $"Changing the value of '{attr.PublicName}' is not allowed.");
            }
        }

        private static void AssertNotReadOnly(AttrAttribute attr, RequestAdapterState state)
        {
            if (attr.Property.SetMethod == null)
            {
                throw new DeserializationException(state.Position, "Attribute is read-only.", $"Attribute '{attr.PublicName}' is read-only.");
            }
        }

        private void ConvertRelationships(IDictionary<string, RelationshipObject> resourceObjectRelationships, IIdentifiable resource,
            ResourceContext resourceContext, RequestAdapterState state)
        {
            using IDisposable _ = state.Position.PushElement("relationships");

            foreach ((string relationshipName, RelationshipObject relationshipObject) in resourceObjectRelationships.EmptyIfNull())
            {
                ConvertRelationship(relationshipName, relationshipObject.Data, resource, resourceContext, state);
            }
        }

        private void ConvertRelationship(string relationshipName, SingleOrManyData<ResourceIdentifierObject> relationshipData, IIdentifiable resource,
            ResourceContext resourceContext, RequestAdapterState state)
        {
            using IDisposable _ = state.Position.PushElement(relationshipName);

            RelationshipAttribute relationship = resourceContext.TryGetRelationshipByPublicName(relationshipName);

            if (relationship == null && _options.AllowUnknownFieldsInRequestBody)
            {
                return;
            }

            AssertIsKnownRelationship(relationship, relationshipName, resourceContext, state);

            object rightValue = _relationshipDataAdapter.Convert(relationshipData, relationship, true, state);

            relationship.SetValue(resource, rightValue);
            state.WritableTargetedFields.Relationships.Add(relationship);
        }
    }
}