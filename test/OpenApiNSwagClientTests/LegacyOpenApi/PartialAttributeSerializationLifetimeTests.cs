using System.Net;
using FluentAssertions;
using JsonApiDotNetCore.OpenApi.Client.NSwag;
using OpenApiNSwagClientTests.LegacyOpenApi.GeneratedCode;
using TestBuildingBlocks;
using Xunit;

namespace OpenApiNSwagClientTests.LegacyOpenApi;

public sealed class PartialAttributeSerializationLifetimeTests
{
    [Fact]
    public async Task Automatically_clears_tracked_properties_after_usage()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId = "XUuiP";

        var requestDocument = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null,
                        LastServicedAt = null
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "is-in-maintenance": false
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Can_preserve_tracked_properties_after_usage()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);

        var apiClient = new LegacyClient(wrapper.HttpClient)
        {
            AutoClearTracked = false
        };

        const string airplaneId = "XUuiP";

        var requestDocument = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = 100
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        requestDocument.Data.Attributes.AirtimeInHours = null;

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "airtime-in-hours": null
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Can_manually_clear_tracked_properties_after_usage()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient)
        {
            AutoClearTracked = false
        };

        const string airplaneId = "XUuiP";

        var requestDocument = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null,
                        LastServicedAt = null
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        apiClient.ClearAllTracked();

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "is-in-maintenance": false
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Different_instances_of_same_type_are_isolated()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId1 = "XUuiP";

        var requestDocument1 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId1,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null
                    }
                }.Initializer
            }
        };

        const string airplaneId2 = "DJy1u";

        var requestDocument2 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId2,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        LastServicedAt = null
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId2, null, requestDocument2));

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId1, null, requestDocument1));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId1}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "airtime-in-hours": null
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Properties_can_be_changed_after_tracking()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId = "XUuiP";

        var requestDocument = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        IsInMaintenance = true
                    }
                }.Initializer
            }
        };

        requestDocument.Data.Attributes.IsInMaintenance = false;

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "is-in-maintenance": false
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Registration_is_unaffected_by_successive_registration_for_document_of_different_type()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId = "XUuiP";

        var requestDocument = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        IsInMaintenance = false
                    }
                }.Initializer
            }
        };

        _ = new CreateAirplaneRequestDocument
        {
            Data = new DataInCreateAirplaneRequest
            {
                Attributes = new TrackChangesFor<AttributesInCreateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null
                    }
                }.Initializer
            }
        };

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "is-in-maintenance": false
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Registration_is_unaffected_by_preceding_disposed_registration_for_different_document_of_same_type()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId1 = "XUuiP";

        var requestDocument1 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId1,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId1, null, requestDocument1));

        const string airplaneId2 = "DJy1u";

        var requestDocument2 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId2,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        SerialNumber = null,
                        ManufacturedInCity = "Everett"
                    }
                }.Initializer
            }
        };

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId2, null, requestDocument2));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId2}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "serial-number": null,
                  "manufactured-in-city": "Everett"
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Registration_is_unaffected_by_preceding_disposed_registration_for_document_of_different_type()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        var requestDocument1 = new CreateAirplaneRequestDocument
        {
            Data = new DataInCreateAirplaneRequest
            {
                Attributes = new TrackChangesFor<AttributesInCreateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        AirtimeInHours = null,
                        Name = "Jay Jay the Jet Plane"
                    }
                }.Initializer
            }
        };

        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PostAirplaneAsync(null, requestDocument1));

        const string airplaneId = "DJy1u";

        var requestDocument2 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        SerialNumber = null,
                        ManufacturedInCity = "Everett"
                    }
                }.Initializer
            }
        };

        wrapper.ChangeResponse(HttpStatusCode.NoContent, null);

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId, null, requestDocument2));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "serial-number": null,
                  "manufactured-in-city": "Everett"
                }
              }
            }
            """);
    }

    [Fact]
    public async Task Registration_is_unaffected_by_preceding_registration_for_different_document_of_same_type()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new LegacyClient(wrapper.HttpClient);

        const string airplaneId1 = "XUuiP";

        var requestDocument1 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId1,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        SerialNumber = null
                    }
                }.Initializer
            }
        };

        const string airplaneId2 = "DJy1u";

        var requestDocument2 = new UpdateAirplaneRequestDocument
        {
            Data = new DataInUpdateAirplaneRequest
            {
                Id = airplaneId2,
                Attributes = new TrackChangesFor<AttributesInUpdateAirplaneRequest>(apiClient)
                {
                    Initializer =
                    {
                        IsInMaintenance = false,
                        AirtimeInHours = null
                    }
                }.Initializer
            }
        };

        // Act
        _ = await ApiResponse.TranslateAsync(async () => await apiClient.PatchAirplaneAsync(airplaneId2, null, requestDocument2));

        // Assert
        wrapper.RequestBody.Should().BeJson($$"""
            {
              "data": {
                "type": "airplanes",
                "id": "{{airplaneId2}}",
                "attributes": {
                  "openapi:discriminator": "airplanes",
                  "airtime-in-hours": null,
                  "is-in-maintenance": false
                }
              }
            }
            """);
    }
}
