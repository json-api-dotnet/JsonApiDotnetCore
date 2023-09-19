using System.Text.Json;
using Humanizer;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.OpenApi.JsonApiObjects.Documents;
using JsonApiDotNetCore.OpenApi.JsonApiObjects.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace JsonApiDotNetCore.OpenApi;

internal sealed class JsonApiOperationIdSelector
{
    private const string ResourceOperationIdTemplate = "[Method] [PrimaryResourceName]";
    private const string ResourceCollectionOperationIdTemplate = ResourceOperationIdTemplate + " Collection";
    private const string SecondaryOperationIdTemplate = ResourceOperationIdTemplate + " [RelationshipName]";
    private const string RelationshipOperationIdTemplate = SecondaryOperationIdTemplate + " Relationship";

    private static readonly IDictionary<Type, string> DocumentOpenTypeToOperationIdTemplateMap = new Dictionary<Type, string>
    {
        [typeof(ResourceCollectionResponseDocument<>)] = ResourceCollectionOperationIdTemplate,
        [typeof(PrimaryResourceResponseDocument<>)] = ResourceOperationIdTemplate,
        [typeof(ResourcePostRequestDocument<>)] = ResourceOperationIdTemplate,
        [typeof(ResourcePatchRequestDocument<>)] = ResourceOperationIdTemplate,
        [typeof(void)] = ResourceOperationIdTemplate,
        [typeof(SecondaryResourceResponseDocument<>)] = SecondaryOperationIdTemplate,
        [typeof(NullableSecondaryResourceResponseDocument<>)] = SecondaryOperationIdTemplate,
        [typeof(ResourceIdentifierCollectionResponseDocument<>)] = RelationshipOperationIdTemplate,
        [typeof(ResourceIdentifierResponseDocument<>)] = RelationshipOperationIdTemplate,
        [typeof(NullableResourceIdentifierResponseDocument<>)] = RelationshipOperationIdTemplate,
        [typeof(ToOneRelationshipInRequest<>)] = RelationshipOperationIdTemplate,
        [typeof(NullableToOneRelationshipInRequest<>)] = RelationshipOperationIdTemplate,
        [typeof(ToManyRelationshipInRequest<>)] = RelationshipOperationIdTemplate
    };

    private readonly IControllerResourceMapping _controllerResourceMapping;
    private readonly JsonNamingPolicy? _namingPolicy;

    public JsonApiOperationIdSelector(IControllerResourceMapping controllerResourceMapping, JsonNamingPolicy? namingPolicy)
    {
        ArgumentGuard.NotNull(controllerResourceMapping);

        _controllerResourceMapping = controllerResourceMapping;
        _namingPolicy = namingPolicy;
    }

    public string GetOperationId(ApiDescription endpoint)
    {
        ArgumentGuard.NotNull(endpoint);

        ResourceType? primaryResourceType = _controllerResourceMapping.GetResourceTypeForController(endpoint.ActionDescriptor.GetActionMethod().ReflectedType);

        if (primaryResourceType == null)
        {
            throw new UnreachableCodeException();
        }

        string template = GetTemplate(primaryResourceType.ClrType, endpoint);

        return ApplyTemplate(template, primaryResourceType, endpoint);
    }

    private static string GetTemplate(Type resourceClrType, ApiDescription endpoint)
    {
        Type requestDocumentType = GetDocumentType(resourceClrType, endpoint);

        if (!DocumentOpenTypeToOperationIdTemplateMap.TryGetValue(requestDocumentType, out string? template))
        {
            throw new UnreachableCodeException();
        }

        return template;
    }

    private static Type GetDocumentType(Type primaryResourceClrType, ApiDescription endpoint)
    {
        var producesResponseTypeAttribute = endpoint.ActionDescriptor.GetFilterMetadata<ProducesResponseTypeAttribute>();

        if (producesResponseTypeAttribute == null)
        {
            throw new UnreachableCodeException();
        }

        ControllerParameterDescriptor? requestBodyDescriptor = endpoint.ActionDescriptor.GetBodyParameterDescriptor();

        Type documentType = requestBodyDescriptor?.ParameterType.GetGenericTypeDefinition() ??
            GetGenericTypeDefinition(producesResponseTypeAttribute.Type) ?? producesResponseTypeAttribute.Type;

        if (documentType == typeof(ResourceCollectionResponseDocument<>))
        {
            Type documentResourceType = producesResponseTypeAttribute.Type.GetGenericArguments()[0];

            if (documentResourceType != primaryResourceClrType)
            {
                documentType = typeof(SecondaryResourceResponseDocument<>);
            }
        }

        return documentType;
    }

    private static Type? GetGenericTypeDefinition(Type type)
    {
        return type.IsConstructedGenericType ? type.GetGenericTypeDefinition() : null;
    }

    private string ApplyTemplate(string operationIdTemplate, ResourceType resourceType, ApiDescription endpoint)
    {
        if (endpoint.RelativePath == null || endpoint.HttpMethod == null)
        {
            throw new UnreachableCodeException();
        }

        string method = endpoint.HttpMethod.ToLowerInvariant();
        string relationshipName = operationIdTemplate.Contains("[RelationshipName]") ? endpoint.RelativePath.Split("/").Last() : string.Empty;

        // @formatter:wrap_chained_method_calls chop_always
        // @formatter:wrap_before_first_method_call true true

        string pascalCaseOperationId = operationIdTemplate
            .Replace("[Method]", method)
            .Replace("[PrimaryResourceName]", resourceType.PublicName.Singularize())
            .Replace("[RelationshipName]", relationshipName)
            .ToPascalCase();

        // @formatter:wrap_before_first_method_call true restore
        // @formatter:wrap_chained_method_calls restore

        return _namingPolicy != null ? _namingPolicy.ConvertName(pascalCaseOperationId) : pascalCaseOperationId;
    }
}
