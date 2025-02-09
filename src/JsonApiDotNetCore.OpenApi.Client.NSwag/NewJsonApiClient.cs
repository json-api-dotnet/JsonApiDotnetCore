using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonApiDotNetCore.OpenApi.Client.NSwag;

public abstract class NewJsonApiClient
{
    private readonly Dictionary<INotifyPropertyChanged, ISet<string>> _propertyStore = [];

    public bool AutoClearTracked { get; set; } = true;
    public bool LogToConsole { get; set; } // TODO: Revisit logging (output type, usages)

    internal void Track<T>(T container)
        where T : INotifyPropertyChanged, new()
    {
        container.PropertyChanged += ContainerOnPropertyChanged;
    }

    public void MarkAsTracked(INotifyPropertyChanged container, params string[] propertyNames)
    {
        ArgumentNullException.ThrowIfNull(container);
        ArgumentNullException.ThrowIfNull(propertyNames);

        if (!_propertyStore.TryGetValue(container, out ISet<string>? properties))
        {
            if (LogToConsole)
            {
                Console.WriteLine($"Tracking instance of type {container.GetType().Name}.");
            }

            properties = new HashSet<string>();
            _propertyStore[container] = properties;
        }

        foreach (string propertyName in propertyNames)
        {
            if (LogToConsole)
            {
                Console.WriteLine($"Tracking property {propertyName} on instance of type {container.GetType().Name}.");
            }

            properties.Add(propertyName);
        }
    }

    private void ContainerOnPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {
        if (sender is INotifyPropertyChanged container && args.PropertyName != null)
        {
            MarkAsTracked(container, args.PropertyName);
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

    public void RemoveContainer(INotifyPropertyChanged container)
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

        serializerSettings.ContractResolver = new IgnoreJsonInheritanceConverterAttributeContractResolver();
        serializerSettings.Converters.Add(new OtherConverter(this));
    }

    private class IgnoreJsonInheritanceConverterAttributeContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);

            if (contract.Converter != null && contract.Converter.GetType().Name == "JsonInheritanceConverter")
            {
                contract.Converter = null;
            }

            return contract;
        }
    }

    private sealed class TrackingContractResolver : InsertDiscriminatorPropertyContractResolver
    {
        private readonly INotifyPropertyChanged _container;
        private readonly ISet<string> _properties;

        public TrackingContractResolver(INotifyPropertyChanged container, ISet<string> properties)
        {
            ArgumentNullException.ThrowIfNull(container);
            ArgumentNullException.ThrowIfNull(properties);

            _container = container;
            _properties = properties;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);

            // TODO: Only at this type, or whole subtree of objects?
            if (jsonProperty.DeclaringType == _container.GetType())
            {
                if (_properties.Contains(jsonProperty.UnderlyingName!))
                {
                    jsonProperty.NullValueHandling = NullValueHandling.Include;
                    jsonProperty.DefaultValueHandling = DefaultValueHandling.Include;
                }
                else
                {
                    jsonProperty.NullValueHandling = NullValueHandling.Ignore;
                    jsonProperty.DefaultValueHandling = DefaultValueHandling.Ignore;
                }
            }

            return jsonProperty;
        }
    }

    private sealed class OtherConverter : JsonConverter
    {
        private readonly DefaultContractResolver _defaultContractResolver = new();
        private readonly NewJsonApiClient _apiClient;

        // TODO: Think more about thread safety, such as switching contract resolvers.
        [ThreadStatic]
        private static bool _isWriting;

        public override bool CanRead => false;

        public override bool CanWrite
        {
            get
            {
                if (_isWriting)
                {
                    _isWriting = false;
                    return false;
                }

                return true;
            }
        }

        public OtherConverter(NewJsonApiClient apiClient)
        {
            ArgumentNullException.ThrowIfNull(apiClient);

            _apiClient = apiClient;
        }

        // Called BEFORE CanRead/CanWrite.
        public override bool CanConvert(Type objectType)
        {
            bool isTrackedType = _apiClient._propertyStore.Keys.Any(containingType => containingType.GetType() == objectType);

            if (isTrackedType)
            {
                return true;
            }

            string? discriminatorName = GetDiscriminatorName(objectType);
            bool requiresDiscriminator = discriminatorName != null && discriminatorName != "openapi:discriminator";

            if (requiresDiscriminator)
            {
                return true;
            }

            return false;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            IContractResolver backupContractResolver = serializer.ContractResolver;
            _isWriting = true;

            try
            {
                if (value is INotifyPropertyChanged container && _apiClient._propertyStore.TryGetValue(container, out ISet<string>? properties))
                {
                    AssertRequiredAttributesHaveNonDefaultValues(container, properties, writer.Path);

                    serializer.ContractResolver = new TrackingContractResolver(container, properties);
                    serializer.Serialize(writer, value);

                    if (_apiClient.AutoClearTracked)
                    {
                        _apiClient.RemoveContainer(container);
                    }
                }
                else
                {
                    serializer.ContractResolver = new InsertDiscriminatorPropertyContractResolver();
                    serializer.Serialize(writer, value);
                }
            }
            finally
            {
                _isWriting = false;
                serializer.ContractResolver = backupContractResolver;
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            // TODO: Implement reading
            throw new NotImplementedException();
        }

        private string? GetDiscriminatorName(Type objectType)
        {
            JsonContract contract = _defaultContractResolver.ResolveContract(objectType);

            if (contract.Converter != null && contract.Converter.GetType().Name == "JsonInheritanceConverter")
            {
                var inheritanceConverter = (BlockedJsonInheritanceConverter)contract.Converter;
                return inheritanceConverter.DiscriminatorName;
            }

            return null;
        }

        private void AssertRequiredAttributesHaveNonDefaultValues(object container, ISet<string> properties, string jsonPath)
        {
            foreach (PropertyInfo propertyInfo in container.GetType().GetProperties())
            {
                bool isTracked = properties.Contains(propertyInfo.Name);

                if (!isTracked)
                {
                    AssertPropertyHasNonDefaultValueIfRequired(container, propertyInfo, jsonPath);
                }
            }
        }

        private static void AssertPropertyHasNonDefaultValueIfRequired(object attributesObject, PropertyInfo propertyInfo, string jsonPath)
        {
            var jsonProperty = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();

            if (jsonProperty is { Required: Required.Always or Required.AllowNull })
            {
                bool propertyHasDefaultValue = PropertyHasDefaultValue(propertyInfo, attributesObject);

                if (propertyHasDefaultValue)
                {
                    throw new JsonSerializationException(
                        $"Cannot write a default value for property '{jsonProperty.PropertyName}'. Property requires a non-default value. Path '{jsonPath}'.",
                        jsonPath, 0, 0, null);
                }
            }
        }

        private static bool PropertyHasDefaultValue(PropertyInfo propertyInfo, object instance)
        {
            object? propertyValue = propertyInfo.GetValue(instance);
            object? defaultValue = GetDefaultValue(propertyInfo.PropertyType);

            return EqualityComparer<object>.Default.Equals(propertyValue, defaultValue);
        }

        private static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }

    private class InsertDiscriminatorPropertyContractResolver : IgnoreJsonInheritanceConverterAttributeContractResolver
    {
        private readonly DefaultContractResolver _defaultContractResolver = new();

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            string? discriminatorName = GetDiscriminatorName(type);

            if (discriminatorName != null)
            {
                JsonProperty discriminatorProperty = CreateDiscriminatorProperty(discriminatorName, type);
                properties.Insert(0, discriminatorProperty);
            }

            return properties;
        }

        private string? GetDiscriminatorName(Type objectType)
        {
            JsonContract contract = _defaultContractResolver.ResolveContract(objectType);

            if (contract.Converter != null && contract.Converter.GetType().Name == "JsonInheritanceConverter")
            {
                var inheritanceConverter = (BlockedJsonInheritanceConverter)contract.Converter;
                return inheritanceConverter.DiscriminatorName;
            }

            return null;
        }

        private static JsonProperty CreateDiscriminatorProperty(string discriminatorName, Type declaringType)
        {
            return new JsonProperty
            {
                PropertyName = discriminatorName,
                PropertyType = typeof(string),
                DeclaringType = declaringType,
                ValueProvider = new DiscriminatorValueProvider(),
                AttributeProvider = null,
                Readable = true,
                Writable = true,
                ShouldSerialize = _ => true
            };
        }

        private sealed class DiscriminatorValueProvider : IValueProvider
        {
            public object? GetValue(object target)
            {
                Type type = target.GetType();

                foreach (Attribute attribute in type.GetCustomAttributes<Attribute>(true))
                {
                    var shim = JsonInheritanceAttributeShim.TryCreate(attribute);

                    if (shim != null && shim.Type == type)
                    {
                        return shim.Key;
                    }
                }

                return null;
            }

            public void SetValue(object target, object? value)
            {
            }
        }

        private sealed class JsonInheritanceAttributeShim
        {
            private readonly Attribute _instance;
            private readonly PropertyInfo _keyProperty;
            private readonly PropertyInfo _typeProperty;

            public string Key => (string)_keyProperty.GetValue(_instance)!;
            public Type Type => (Type)_typeProperty.GetValue(_instance)!;

            private JsonInheritanceAttributeShim(Attribute instance, Type type)
            {
                _instance = instance;
                _keyProperty = type.GetProperty("Key") ?? throw new ArgumentException("Key property not found.", nameof(instance));
                _typeProperty = type.GetProperty("Type") ?? throw new ArgumentException("Type property not found.", nameof(instance));
            }

            public static JsonInheritanceAttributeShim? TryCreate(Attribute attribute)
            {
                ArgumentNullException.ThrowIfNull(attribute);

                Type type = attribute.GetType();
                return type.Name == "JsonInheritanceAttribute" ? new JsonInheritanceAttributeShim(attribute, type) : null;
            }
        }
    }
}
