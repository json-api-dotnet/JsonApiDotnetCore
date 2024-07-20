using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace JsonApiDotNetCore.OpenApi.Client.NSwag;

public abstract class NewJsonApiClient
{
    private readonly Dictionary<INotifyPropertyChanged, ISet<string>> _propertyStore = [];

    internal void Track<T>(T container)
        where T : INotifyPropertyChanged, new()
    {
        container.PropertyChanged += ContainerOnPropertyChanged;
    }

    private void ContainerOnPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {
        if (sender is INotifyPropertyChanged container && args.PropertyName != null)
        {
            if (!_propertyStore.TryGetValue(container, out ISet<string>? properties))
            {
                properties = new HashSet<string>();
                _propertyStore[container] = properties;
            }

            properties.Add(args.PropertyName);
        }
    }

    public void Reset()
    {
        foreach (INotifyPropertyChanged container in _propertyStore.Keys)
        {
            container.PropertyChanged -= ContainerOnPropertyChanged;
        }

        _propertyStore.Clear();
    }

    protected void SetSerializerSettingsForJsonApi(JsonSerializerSettings serializerSettings)
    {
        ArgumentNullException.ThrowIfNull(serializerSettings);

        serializerSettings.Converters.Add(new PropertyTrackingConverter(this));
    }

    private sealed class PropertyTrackingConverter : JsonConverter
    {
        private static readonly AsyncLocal<bool> IsDisabled = new();
        private readonly NewJsonApiClient _apiClient;

        public override bool CanRead => false;
        public override bool CanWrite => true;

        public PropertyTrackingConverter(NewJsonApiClient apiClient)
        {
            ArgumentNullException.ThrowIfNull(apiClient);

            _apiClient = apiClient;
        }

        public override bool CanConvert(Type objectType)
        {
            return !IsDisabled.Value && _apiClient._propertyStore.Keys.Any(container => container.GetType() == objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            try
            {
                IsDisabled.Value = true;

                if (value is INotifyPropertyChanged container && _apiClient._propertyStore.TryGetValue(container, out ISet<string>? properties))
                {
                    writer.WriteStartObject();

                    foreach (string propertyName in properties)
                    {
                        PropertyInfo property = container.GetType().GetProperty(propertyName)!;

                        string jsonPropertyName = property.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? property.Name;
                        writer.WritePropertyName(jsonPropertyName);

                        object? jsonPropertyValue = property.GetValue(container);
                        serializer.Serialize(writer, jsonPropertyValue);
                    }

                    writer.WriteEndObject();
                }
                else
                {
                    serializer.Serialize(writer, value);
                }
            }
            finally
            {
                IsDisabled.Value = false;
            }
        }
    }
}
