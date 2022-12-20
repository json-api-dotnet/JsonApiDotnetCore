using System.Net;
using FluentAssertions;
using FluentAssertions.Specialized;
using JsonApiDotNetCore.Middleware;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using OpenApiClientTests.SchemaProperties.NullableReferenceTypesEnabled.GeneratedCode;
using TestBuildingBlocks;
using Xunit;

namespace OpenApiClientTests.SchemaProperties.NullableReferenceTypesEnabled;

public sealed class RequiredAttributesTests
{
    private const string CowUrl = "http://localhost/cows";

    [Fact]
    public async Task Can_exclude_optional_attributes()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var requestDocument = new CowPostRequestDocument
        {
            Data = new CowDataInPostRequest
            {
                Attributes = new CowAttributesInPostRequest
                {
                    Name = "Cow",
                    NameOfCurrentFarm = "Cow and Chicken Farm",
                    Nickname = "Cow",
                    Weight = 30,
                    HasProducedMilk = true
                }
            }
        };

        using (apiClient.OmitDefaultValuesForAttributesInRequestDocument<CowPostRequestDocument, CowAttributesInPostRequest>(requestDocument))
        {
            // Act
            await ApiResponse.TranslateAsync(async () => await apiClient.PostCowAsync(requestDocument));
        }

        // Assert
        wrapper.Request.ShouldNotBeNull();
        wrapper.Request.Headers.GetValue(HeaderNames.Accept).Should().Be(HeaderConstants.MediaType);
        wrapper.Request.Method.Should().Be(HttpMethod.Post);
        wrapper.Request.RequestUri.Should().Be(CowUrl);
        wrapper.Request.Content.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType!.ToString().Should().Be(HeaderConstants.MediaType);

        wrapper.RequestBody.Should().BeJson(@"{
  ""data"": {
    ""type"": ""cows"",
    ""attributes"": {
      ""name"": ""Cow"",
      ""nameOfCurrentFarm"": ""Cow and Chicken Farm"",
      ""nickname"": ""Cow"",
      ""weight"": 30,
      ""hasProducedMilk"": true
    }
  }
}");
    }

    [Theory]
    [InlineData(nameof(CowAttributesInResponse.Name), "name")]
    [InlineData(nameof(CowAttributesInResponse.NameOfCurrentFarm), "nameOfCurrentFarm")]
    [InlineData(nameof(CowAttributesInResponse.Nickname), "nickname")]
    [InlineData(nameof(CowAttributesInResponse.Weight), "weight")]
    [InlineData(nameof(CowAttributesInResponse.HasProducedMilk), "hasProducedMilk")]
    public async Task Cannot_exclude_required_attribute_when_performing_POST(string propertyName, string jsonName)
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var attributesInPostRequest = new CowAttributesInPostRequest
        {
            Name = "Cow",
            NameOfCurrentFarm = "Cow and Chicken Farm",
            NameOfPreviousFarm = "Animal Farm",
            Nickname = "Cow",
            Age = 10,
            Weight = 30,
            TimeAtCurrentFarmInDays = 100,
            HasProducedMilk = true
        };

        attributesInPostRequest.SetPropertyToDefaultValue(propertyName);

        var requestDocument = new CowPostRequestDocument
        {
            Data = new CowDataInPostRequest
            {
                Attributes = attributesInPostRequest
            }
        };

        using (apiClient.OmitDefaultValuesForAttributesInRequestDocument<CowPostRequestDocument, CowAttributesInPostRequest>(requestDocument))
        {
            // Act
            Func<Task<CowPrimaryResponseDocument?>> action = async () =>
                await ApiResponse.TranslateAsync(async () => await apiClient.PostCowAsync(requestDocument));

            // Assert
            ExceptionAssertions<JsonSerializationException> assertion = await action.Should().ThrowExactlyAsync<JsonSerializationException>();
            JsonSerializationException exception = assertion.Subject.Single();

            exception.Message.Should().Be($"Ignored property '{jsonName}' must have a value because it is required. Path 'data.attributes'.");
        }
    }

    [Fact]
    public async Task Can_exclude_attributes_that_are_required_for_POST_when_performing_PATCH()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var requestDocument = new CowPatchRequestDocument
        {
            Data = new CowDataInPatchRequest
            {
                Id = "1",
                Attributes = new CowAttributesInPatchRequest
                {
                    NameOfPreviousFarm = "Animal Farm",
                    Age = 10,
                    TimeAtCurrentFarmInDays = 100
                }
            }
        };

        using (apiClient.OmitDefaultValuesForAttributesInRequestDocument<CowPatchRequestDocument, CowAttributesInPatchRequest>(requestDocument))
        {
            // Act
            await ApiResponse.TranslateAsync(async () => await apiClient.PatchCowAsync(1, requestDocument));
        }

        // Assert
        wrapper.Request.ShouldNotBeNull();
        wrapper.Request.Headers.GetValue(HeaderNames.Accept).Should().Be(HeaderConstants.MediaType);
        wrapper.Request.Method.Should().Be(HttpMethod.Patch);
        wrapper.Request.RequestUri.Should().Be(CowUrl + "/1");
        wrapper.Request.Content.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType!.ToString().Should().Be(HeaderConstants.MediaType);

        wrapper.RequestBody.Should().BeJson(@"{
  ""data"": {
    ""type"": ""cows"",
    ""id"": ""1"",
    ""attributes"": {
      ""nameOfPreviousFarm"": ""Animal Farm"",
      ""age"": 10,
      ""timeAtCurrentFarmInDays"": 100
    }
  }
}");
    }

    [Fact]
    public async Task Cannot_exclude_id_when_performing_PATCH()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var requestDocument = new CowPatchRequestDocument
        {
            Data = new CowDataInPatchRequest
            {
                Attributes = new CowAttributesInPatchRequest
                {
                    Name = "Cow",
                    NameOfCurrentFarm = "Cow and Chicken Farm",
                    NameOfPreviousFarm = "Animal Farm",
                    Nickname = "Cow",
                    Age = 10,
                    Weight = 30,
                    TimeAtCurrentFarmInDays = 100,
                    HasProducedMilk = true
                }
            }
        };

        // Act
        Func<Task> action = async () => await ApiResponse.TranslateAsync(async () => await apiClient.PatchCowAsync(1, requestDocument));

        // Assert
        await action.Should().ThrowAsync<JsonSerializationException>();
        ExceptionAssertions<JsonSerializationException> assertion = await action.Should().ThrowExactlyAsync<JsonSerializationException>();
        JsonSerializationException exception = assertion.Subject.Single();

        exception.Message.Should().Be("Cannot write a null value for property 'id'. Property requires a value. Path 'data'.");
    }

    [Fact]
    public async Task Can_clear_nullable_attributes()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var requestDocument = new CowPostRequestDocument
        {
            Data = new CowDataInPostRequest
            {
                Attributes = new CowAttributesInPostRequest
                {
                    NameOfPreviousFarm = null,
                    TimeAtCurrentFarmInDays = null,
                    Name = "Cow",
                    NameOfCurrentFarm = "Cow and Chicken Farm",
                    Nickname = "Cow",
                    Age = 10,
                    Weight = 30,
                    HasProducedMilk = true
                }
            }
        };

        using (apiClient.OmitDefaultValuesForAttributesInRequestDocument<CowPostRequestDocument, CowAttributesInPostRequest>(requestDocument,
            cow => cow.NameOfPreviousFarm, cow => cow.TimeAtCurrentFarmInDays))
        {
            // Act
            await ApiResponse.TranslateAsync(async () => await apiClient.PostCowAsync(requestDocument));
        }

        // Assert
        wrapper.Request.ShouldNotBeNull();
        wrapper.Request.Headers.GetValue(HeaderNames.Accept).Should().Be(HeaderConstants.MediaType);
        wrapper.Request.Method.Should().Be(HttpMethod.Post);
        wrapper.Request.RequestUri.Should().Be(CowUrl);
        wrapper.Request.Content.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType!.ToString().Should().Be(HeaderConstants.MediaType);

        wrapper.RequestBody.Should().BeJson(@"{
  ""data"": {
    ""type"": ""cows"",
    ""attributes"": {
      ""name"": ""Cow"",
      ""nameOfCurrentFarm"": ""Cow and Chicken Farm"",
      ""nameOfPreviousFarm"": null,
      ""nickname"": ""Cow"",
      ""age"": 10,
      ""weight"": 30,
      ""timeAtCurrentFarmInDays"": null,
      ""hasProducedMilk"": true
    }
  }
}");
    }

    [Fact]
    public async Task Can_set_default_value_to_ValueType_attributes()
    {
        // Arrange
        using var wrapper = FakeHttpClientWrapper.Create(HttpStatusCode.NoContent, null);
        var apiClient = new NullableReferenceTypesEnabledClient(wrapper.HttpClient);

        var requestDocument = new CowPostRequestDocument
        {
            Data = new CowDataInPostRequest
            {
                Attributes = new CowAttributesInPostRequest
                {
                    Name = "Cow",
                    NameOfCurrentFarm = "Cow and Chicken Farm",
                    NameOfPreviousFarm = "Animal Farm",
                    Nickname = "Cow",
                    TimeAtCurrentFarmInDays = 100
                }
            }
        };

        // Act
        await ApiResponse.TranslateAsync(async () => await apiClient.PostCowAsync(requestDocument));

        // Assert
        wrapper.Request.ShouldNotBeNull();
        wrapper.Request.Headers.GetValue(HeaderNames.Accept).Should().Be(HeaderConstants.MediaType);
        wrapper.Request.Method.Should().Be(HttpMethod.Post);
        wrapper.Request.RequestUri.Should().Be(CowUrl);
        wrapper.Request.Content.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType.Should().NotBeNull();
        wrapper.Request.Content!.Headers.ContentType!.ToString().Should().Be(HeaderConstants.MediaType);

        wrapper.RequestBody.Should().BeJson(@"{
  ""data"": {
    ""type"": ""cows"",
    ""attributes"": {
      ""name"": ""Cow"",
      ""nameOfCurrentFarm"": ""Cow and Chicken Farm"",
      ""nameOfPreviousFarm"": ""Animal Farm"",
      ""nickname"": ""Cow"",
      ""age"": 0,
      ""weight"": 0,
      ""timeAtCurrentFarmInDays"": 100,
      ""hasProducedMilk"": false
    }
  }
}");
    }
}