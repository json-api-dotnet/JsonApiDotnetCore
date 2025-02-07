using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonApiDotNetCore.OpenApi.Client.NSwag;

public abstract class NewJsonApiClient
{
    private readonly Dictionary<INotifyPropertyChanged, ISet<string>> _propertyStore = [];
    private JsonSerializerSettings _serializerSettings = null!;

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

        _serializerSettings = serializerSettings;
        //serializerSettings.Converters.Insert(0, new PropertyTrackingWriteConverter(this));
        //serializerSettings.Converters.Insert(0, new PropertyTrackingReadConverter(this));

        //serializerSettings.Converters.Add(new PropertyTrackingReadConverter(this));
        serializerSettings.Converters.Add(new PropertyTrackingWriteConverter(this));

        serializerSettings.ContractResolver = new JsonApiFieldContractResolver(this);
        //serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }

    private sealed class JsonApiFieldContractResolver : DefaultContractResolver
    {
        private readonly NewJsonApiClient _apiClient;

        public JsonApiFieldContractResolver(NewJsonApiClient apiClient)
        {
            ArgumentNullException.ThrowIfNull(apiClient);

            _apiClient = apiClient;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            Console.WriteLine($"CreateProperty for {member.Name}");

            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);

            if (member.ReflectedType != null && _apiClient._propertyStore.Keys.Any(containingType => containingType.GetType() == member.ReflectedType))
            {
                //jsonProperty.NullValueHandling = NullValueHandling.Include;
                //jsonProperty.DefaultValueHandling = DefaultValueHandling.Include;
            }

            return jsonProperty;
        }

        protected override JsonConverter? ResolveContractConverter(Type objectType)
        {
            bool isTrackedType = _apiClient._propertyStore.Keys.Any(containingType => containingType.GetType() == objectType);

            if (isTrackedType)
            {
                Console.WriteLine($"ResolveContractConverter for {objectType.Name} (tracked)");
            }
            else
            {
                Console.WriteLine($"ResolveContractConverter for {objectType.Name}");
            }

            if (_apiClient._propertyStore.Keys.Any(containingType => containingType.GetType() == objectType))
            {
                return new PropertyTrackingWriteConverter(_apiClient);
            }

            return base.ResolveContractConverter(objectType);
        }
    }

    public sealed class AlwaysIncludeContractResolver : DefaultContractResolver
    {
        private readonly ISet<string> _properties;

        public AlwaysIncludeContractResolver():this(new HashSet<string>()){}

        public AlwaysIncludeContractResolver(ISet<string> properties)
        {
            ArgumentNullException.ThrowIfNull(properties);

            _properties = properties;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);

            //if (_properties.Contains(member.Name))
            {
                jsonProperty.NullValueHandling = NullValueHandling.Include;
                jsonProperty.DefaultValueHandling = DefaultValueHandling.Include;
            }

            return jsonProperty;
        }
    }

    private sealed class PropertyTrackingWriteConverter : JsonConverter
    {
        private static readonly AsyncLocal<bool> IsWriting = new();
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
            bool result;

            if (IsWriting.Value)
            {
                //IsWriting.Value = false;
                result = false;
            }
            else
            {
                bool canConvert = _apiClient._propertyStore.Keys.Any(container => container.GetType() == objectType);
                result = canConvert;
            }

            Console.WriteLine($"PropertyTrackingWriteConverter.CanConvert for {objectType.Name} => {result}");
            return result;

            //



            /*if (IsDisabled.Value)
            {
                IsDisabled.Value = false;
                return false;
            }*/

            //return canConvert;
            //return true;
            //return !IsDisabled.Value;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            try
            {
                IsWriting.Value = true;
                //bool isObjectTracked = value is INotifyPropertyChanged container && _apiClient._propertyStore.TryGetValue(container, out ISet<string>? properties);
                //bool isObjectTracked = value is INotifyPropertyChanged container && _apiClient._propertyStore.ContainsKey(container);

                

                if (value is INotifyPropertyChanged container && _apiClient._propertyStore.TryGetValue(container, out ISet<string>? properties))
                {
                    Console.WriteLine($"PropertyTrackingWriteConverter.WriteJson for {value.GetType().Name}");

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
                    
                    var tempSettings = new JsonSerializerSettings(_apiClient._serializerSettings);
                    tempSettings.ContractResolver = null;
                    var tempSerializer = JsonSerializer.Create(tempSettings);


                    //serializer.Serialize(writer, value);
                    tempSerializer.Serialize(writer, value);
                }
            }
            finally
            {
                IsWriting.Value = false;
            }
        }
    }
}
