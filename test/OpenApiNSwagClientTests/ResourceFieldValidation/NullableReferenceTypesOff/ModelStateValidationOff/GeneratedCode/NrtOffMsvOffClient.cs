using JsonApiDotNetCore.OpenApi.Client.NSwag;
using Newtonsoft.Json;

#pragma warning disable CA1852 // Seal internal types

namespace OpenApiNSwagClientTests.ResourceFieldValidation.NullableReferenceTypesOff.ModelStateValidationOff.GeneratedCode;

internal partial class NrtOffMsvOffClient : JsonApiClient
{
    partial void Initialize()
    {
        _instanceSettings = new JsonSerializerSettings(_settings.Value)
        {
            Formatting = Formatting.Indented
        };

        SetSerializerSettingsForJsonApi(_instanceSettings);
    }
}
