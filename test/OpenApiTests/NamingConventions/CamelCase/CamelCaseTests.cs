using System.Text.Json;
using TestBuildingBlocks;
using Xunit;

namespace OpenApiTests.NamingConventions.CamelCase;

public sealed class CamelCaseTests : IClassFixture<OpenApiTestContext<CamelCaseNamingConventionStartup<NamingConventionDbContext>, NamingConventionDbContext>>
{
    private readonly OpenApiTestContext<CamelCaseNamingConventionStartup<NamingConventionDbContext>, NamingConventionDbContext> _testContext;

    public CamelCaseTests(OpenApiTestContext<CamelCaseNamingConventionStartup<NamingConventionDbContext>, NamingConventionDbContext> testContext)
    {
        _testContext = testContext;

        testContext.UseController<SupermarketsController>();
        testContext.UseController<StaffMembersController>();

        testContext.SwaggerDocumentOutputDirectory = $"{GetType().Namespace!.Replace('.', '/')}/GeneratedSwagger";
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetCollection_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketCollection");
            });

            documentSchemaRefId = getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("supermarketCollectionResponseDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? topLevelLinksSchemaRefId = null;
            string? resourceDataSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainPath("jsonapi.allOf[0].$ref").ShouldBeSchemaReferenceId("jsonapi");

                topLevelLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("resourceCollectionTopLevelLinks").SchemaReferenceId;

                resourceDataSchemaRefId = propertiesElement.Should().ContainPath("data.items.$ref").ShouldBeSchemaReferenceId("supermarketDataInResponse")
                    .SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{topLevelLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
                propertiesElement.Should().ContainProperty("describedby");
                propertiesElement.Should().ContainProperty("first");
                propertiesElement.Should().ContainProperty("last");
                propertiesElement.Should().ContainProperty("prev");
                propertiesElement.Should().ContainProperty("next");
            });

            string? resourceLinksSchemaRefId = null;
            string? resourceAttributesInResponseSchemaRefId = null;
            string? resourceRelationshipInResponseSchemaRefId = null;

            string abstractResourceDataSchemaRefId = schemasElement.Should().ContainPath($"{resourceDataSchemaRefId}.allOf[0].$ref")
                .ShouldBeSchemaReferenceId("dataInResponse").SchemaReferenceId;

            schemasElement.Should().ContainPath($"{abstractResourceDataSchemaRefId}.discriminator.mapping").With(mappingElement =>
            {
                mappingElement.Should().ContainPath("supermarkets").ShouldBeSchemaReferenceId("supermarketDataInResponse");
                mappingElement.Should().ContainPath("staffMembers").ShouldBeSchemaReferenceId("staffMemberDataInResponse");
            });

            schemasElement.Should().ContainPath($"{resourceDataSchemaRefId}.allOf[1].properties").With(propertiesElement =>
            {
                resourceLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref").ShouldBeSchemaReferenceId("resourceLinks")
                    .SchemaReferenceId;

                resourceAttributesInResponseSchemaRefId = propertiesElement.Should().ContainPath("attributes.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("supermarketAttributesInResponse").SchemaReferenceId;

                resourceRelationshipInResponseSchemaRefId = propertiesElement.Should().ContainPath("relationships.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("supermarketRelationshipsInResponse").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{resourceLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
            });

            schemasElement.Should().ContainPath($"{resourceAttributesInResponseSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("nameOfCity");
                propertiesElement.Should().ContainProperty("kind");
                propertiesElement.Should().ContainPath("kind.allOf[0].$ref").ShouldBeSchemaReferenceId("supermarketType");
            });

            string? nullableToOneResourceResponseDataSchemaRefId = null;

            schemasElement.Should().ContainPath($"{resourceRelationshipInResponseSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("storeManager");

                propertiesElement.Should().ContainPath("storeManager.allOf[0].$ref").ShouldBeSchemaReferenceId("toOneStaffMemberInResponse");

                nullableToOneResourceResponseDataSchemaRefId = propertiesElement.Should().ContainPath("backupStoreManager.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("nullableToOneStaffMemberInResponse").SchemaReferenceId;

                propertiesElement.Should().ContainProperty("cashiers");
                propertiesElement.Should().ContainPath("cashiers.allOf[0].$ref").ShouldBeSchemaReferenceId("toManyStaffMemberInResponse");
            });

            string? relationshipLinksSchemaRefId = null;
            string? relatedResourceIdentifierSchemaRefId = null;

            schemasElement.Should().ContainPath($"{nullableToOneResourceResponseDataSchemaRefId}.properties").With(propertiesElement =>
            {
                relationshipLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref").ShouldBeSchemaReferenceId("relationshipLinks")
                    .SchemaReferenceId;

                relatedResourceIdentifierSchemaRefId = propertiesElement.Should().ContainPath("data.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("staffMemberIdentifier").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{relationshipLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
                propertiesElement.Should().ContainProperty("related");
            });

            string? relatedResourceTypeSchemaRefId = null;

            schemasElement.Should().ContainPath($"{relatedResourceIdentifierSchemaRefId}.properties").With(propertiesElement =>
            {
                relatedResourceTypeSchemaRefId = propertiesElement.Should().ContainPath("type.$ref").ShouldBeSchemaReferenceId("staffMemberResourceType")
                    .SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{relatedResourceTypeSchemaRefId}.enum").With(codeElement =>
            {
                codeElement.Should().ContainArrayElement("staffMembers");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetSingle_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets/{id}.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarket");
            });

            documentSchemaRefId = getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("supermarketPrimaryResponseDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? topLevelLinksSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                topLevelLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref").ShouldBeSchemaReferenceId("resourceTopLevelLinks")
                    .SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{topLevelLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
                propertiesElement.Should().ContainProperty("describedby");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetSecondary_endpoint_with_single_resource()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets/{id}/storeManager.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketStoreManager");
            });

            documentSchemaRefId = getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("staffMemberSecondaryResponseDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? resourceDataSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                resourceDataSchemaRefId = propertiesElement.Should().ContainPath("data.allOf[0].$ref").ShouldBeSchemaReferenceId("staffMemberDataInResponse")
                    .SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{resourceDataSchemaRefId}.allOf[1].properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainPath("attributes.allOf[0].$ref").ShouldBeSchemaReferenceId("staffMemberAttributesInResponse");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetSecondary_endpoint_with_nullable_resource()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/backupStoreManager.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketBackupStoreManager");
            });

            getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("nullableStaffMemberSecondaryResponseDocument");
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetSecondary_endpoint_with_resources()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/cashiers.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketCashiers");
            });

            getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("staffMemberCollectionResponseDocument");
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetRelationship_endpoint_with_ToOne_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets/{id}/relationships/storeManager.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketStoreManagerRelationship");
            });

            documentSchemaRefId = getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("staffMemberIdentifierResponseDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? topLevelLinksSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                topLevelLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("resourceIdentifierTopLevelLinks").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{topLevelLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
                propertiesElement.Should().ContainProperty("describedby");
                propertiesElement.Should().ContainProperty("related");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetRelationship_endpoint_with_nullable_ToOne_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/backupStoreManager.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketBackupStoreManagerRelationship");
            });

            getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("nullableStaffMemberIdentifierResponseDocument");
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_GetRelationship_endpoint_with_ToMany_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets/{id}/relationships/cashiers.get").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("getSupermarketCashiersRelationship");
            });

            documentSchemaRefId = getElement.Should().ContainPath("responses.200.content['application/vnd.api+json'].schema.$ref")
                .ShouldBeSchemaReferenceId("staffMemberIdentifierCollectionResponseDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? topLevelLinksSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                topLevelLinksSchemaRefId = propertiesElement.Should().ContainPath("links.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("resourceIdentifierCollectionTopLevelLinks").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{topLevelLinksSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("self");
                propertiesElement.Should().ContainProperty("describedby");
                propertiesElement.Should().ContainProperty("related");
                propertiesElement.Should().ContainProperty("first");
                propertiesElement.Should().ContainProperty("last");
                propertiesElement.Should().ContainProperty("prev");
                propertiesElement.Should().ContainProperty("next");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_Post_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets.post").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("postSupermarket");
            });

            documentSchemaRefId = getElement.Should().ContainPath("requestBody.content['application/vnd.api+json'].schema.allOf[0].$ref")
                .ShouldBeSchemaReferenceId("createSupermarketRequestDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? resourceDataSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                resourceDataSchemaRefId = propertiesElement.Should().ContainPath("data.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("dataInCreateSupermarketRequest").SchemaReferenceId;
            });

            string? resourceRelationshipInPostRequestSchemaRefId = null;

            schemasElement.Should().ContainPath($"{resourceDataSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainPath("attributes.allOf[0].$ref").ShouldBeSchemaReferenceId("attributesInCreateSupermarketRequest");

                resourceRelationshipInPostRequestSchemaRefId = propertiesElement.Should().ContainPath("relationships.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("relationshipsInCreateSupermarketRequest").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{resourceRelationshipInPostRequestSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainProperty("storeManager");
                propertiesElement.Should().ContainPath("storeManager.allOf[0].$ref").ShouldBeSchemaReferenceId("toOneStaffMemberInRequest");

                propertiesElement.Should().ContainProperty("backupStoreManager");
                propertiesElement.Should().ContainPath("backupStoreManager.allOf[0].$ref").ShouldBeSchemaReferenceId("nullableToOneStaffMemberInRequest");

                propertiesElement.Should().ContainProperty("cashiers");
                propertiesElement.Should().ContainPath("cashiers.allOf[0].$ref").ShouldBeSchemaReferenceId("toManyStaffMemberInRequest");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_PostRelationship_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/cashiers.post").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("postSupermarketCashiersRelationship");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_Patch_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        string? documentSchemaRefId = null;

        document.Should().ContainPath("paths./supermarkets/{id}.patch").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("patchSupermarket");
            });

            documentSchemaRefId = getElement.Should().ContainPath("requestBody.content['application/vnd.api+json'].schema.allOf[0].$ref")
                .ShouldBeSchemaReferenceId("updateSupermarketRequestDocument").SchemaReferenceId;
        });

        document.Should().ContainPath("components.schemas").With(schemasElement =>
        {
            string? resourceDataSchemaRefId = null;

            schemasElement.Should().ContainPath($"{documentSchemaRefId}.properties").With(propertiesElement =>
            {
                resourceDataSchemaRefId = propertiesElement.Should().ContainPath("data.allOf[0].$ref")
                    .ShouldBeSchemaReferenceId("dataInUpdateSupermarketRequest").SchemaReferenceId;
            });

            schemasElement.Should().ContainPath($"{resourceDataSchemaRefId}.properties").With(propertiesElement =>
            {
                propertiesElement.Should().ContainPath("attributes.allOf[0].$ref").ShouldBeSchemaReferenceId("attributesInUpdateSupermarketRequest");
                propertiesElement.Should().ContainPath("relationships.allOf[0].$ref").ShouldBeSchemaReferenceId("relationshipsInUpdateSupermarketRequest");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_PatchRelationship_endpoint_with_ToOne_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/storeManager.patch").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("patchSupermarketStoreManagerRelationship");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_PatchRelationship_endpoint_with_nullable_ToOne_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/backupStoreManager.patch").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("patchSupermarketBackupStoreManagerRelationship");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_PatchRelationship_endpoint_with_ToMany_relationship()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/cashiers.patch").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("patchSupermarketCashiersRelationship");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_Delete_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}.delete").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("deleteSupermarket");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_DeleteRelationship_endpoint()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("paths./supermarkets/{id}/relationships/cashiers.delete").With(getElement =>
        {
            getElement.Should().ContainPath("operationId").With(operationElement =>
            {
                operationElement.Should().Be("deleteSupermarketCashiersRelationship");
            });
        });
    }

    [Fact]
    public async Task Casing_convention_is_applied_to_error_schema()
    {
        // Act
        JsonElement document = await _testContext.GetSwaggerDocumentAsync();

        // Assert
        document.Should().ContainPath("components.schemas.errorResponseDocument");
        document.Should().ContainPath("components.schemas.errorTopLevelLinks");
    }
}
