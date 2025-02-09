using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonApiDotNetCore.OpenApi.Client.NSwag;

public abstract class NewJsonApiClient
{
    private readonly Dictionary<INotifyPropertyChanged, ISet<string>> _propertyStore = [];
    private JsonSerializer? _alternateSerializer;

    public bool AutoClearTracked { get; set; } = true;
    public bool LogToConsole { get; set; }

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

            if (LogToConsole)
            {
                Console.WriteLine($"Tracking property {args.PropertyName} on instance of type {sender.GetType().Name}.");
            }

            properties.Add(args.PropertyName);
        }
    }

    public void ClearTracked()
    {
        if (LogToConsole)
        {
            Console.WriteLine($"Clearing tracked properties for {_propertyStore.Count} instances.");
        }

        foreach (INotifyPropertyChanged container in _propertyStore.Keys)
        {
            container.PropertyChanged -= ContainerOnPropertyChanged;
        }

        _propertyStore.Clear();
    }

    private void RemoveContainer(INotifyPropertyChanged container)
    {
        if (LogToConsole)
        {
            Console.WriteLine($"Auto-clearing tracked properties for instance of type {container.GetType().Name}.");
        }

        container.PropertyChanged -= ContainerOnPropertyChanged;
        _propertyStore.Remove(container);
    }

    protected void SetSerializerSettingsForJsonApi(JsonSerializerSettings serializerSettings)
    {
        ArgumentNullException.ThrowIfNull(serializerSettings);

        // NSwag adds [JsonConverter(typeof(JsonInheritanceConverter), "type")] on types to write the discriminator.
        // This annotation is preferred over converters in the serializer settings, so ours wouldn't be used if we registered one.
        // Once JsonInheritanceConverter recursively calls into itself and denies to handle, only the built-in converters are used.

        // To intercept, we insert a ContractResolver that returns our converter for tracked properties.
        // But it is only during write that we can determine whether to write nulls/defaults, so we must be able to fall back to something.
        // Delegating to the existing serializer fails with "Self referencing loop detected" (we are already in too deep), which is why
        // we use a second serializer instance to handle that case.

        _alternateSerializer = JsonSerializer.Create(new JsonSerializerSettings(serializerSettings));
        serializerSettings.ContractResolver = new JsonApiFieldContractResolver(this);
    }

    private sealed class JsonApiFieldContractResolver : DefaultContractResolver
    {
        private readonly NewJsonApiClient _apiClient;

        public JsonApiFieldContractResolver(NewJsonApiClient apiClient)
        {
            ArgumentNullException.ThrowIfNull(apiClient);

            _apiClient = apiClient;
        }

        protected override JsonConverter? ResolveContractConverter(Type objectType)
        {
            bool isTrackedType = _apiClient._propertyStore.Keys.Any(containingType => containingType.GetType() == objectType);

            if (isTrackedType && _apiClient.LogToConsole)
            {
                Console.WriteLine($"{nameof(JsonApiFieldContractResolver)}.{nameof(ResolveContractConverter)} for type {objectType.Name} (tracked)");
            }

            return isTrackedType ? new PropertyTrackingWriteConverter(_apiClient) : base.ResolveContractConverter(objectType);
        }
    }

    private sealed class PropertyTrackingWriteConverter : JsonConverter
    {
        [ThreadStatic]
        private static bool _isWriting;

        private readonly NewJsonApiClient _apiClient;

        public override bool CanRead => false;
        public override bool CanWrite => true;

        public PropertyTrackingWriteConverter(NewJsonApiClient apiClient)
        {
            ArgumentNullException.ThrowIfNull(apiClient);

            _apiClient = apiClient;
        }

        public override bool CanConvert(Type objectType)
        {
            if (_isWriting)
            {
                if (_apiClient.LogToConsole)
                {
                    Console.WriteLine($"{nameof(PropertyTrackingWriteConverter)}.{nameof(CanConvert)} returns false (already writing).");
                }

                return false;
            }

            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            try
            {
                _isWriting = true;

                if (value is INotifyPropertyChanged container && _apiClient._propertyStore.TryGetValue(container, out ISet<string>? properties))
                {
                    if (_apiClient.LogToConsole)
                    {
                        Console.WriteLine($"Writing tracked properties for instance of type {container.GetType().Name}.");
                    }

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

                    if (_apiClient.AutoClearTracked)
                    {
                        _apiClient.RemoveContainer(container);
                    }
                }
                else
                {
                    if (_apiClient.LogToConsole)
                    {
                        Console.WriteLine($"Type {value?.GetType().Name} is tracked, but this instance is not. Delegating to alternate serializer.");
                    }

                    _apiClient._alternateSerializer!.Serialize(writer, value);
                }
            }
            finally
            {
                _isWriting = false;
            }
        }
    }
}
