using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace TheGamesDBApiWrapper.Resolver
{
    /// <summary>
    /// Custom JSON converter for resolving dependencies via DI in models.
    /// </summary>
    public class DIJsonConverter<T> : JsonConverter<T> where T : class
    {
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DIJsonConverter{T}"/> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        public DIJsonConverter(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Deserialize the object using the default behavior
            var jsonDocument = JsonDocument.ParseValue(ref reader);
            var instance = ActivatorUtilities.CreateInstance(_provider, typeToConvert) as T;

            if (instance == null)
            {
                throw new InvalidOperationException($"Unable to create an instance of type {typeToConvert.FullName}.");
            }

            // Populate properties marked with [DIResolve]
            var properties = typeToConvert.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(prop => prop.GetCustomAttribute<Annotations.DIResolve>() != null);

            foreach (var property in properties)
            {
                var service = _provider.GetService(property.PropertyType);
                if (service != null)
                {
                    property.SetValue(instance, service);
                }
            }

            // Populate other properties from JSON
            foreach (var property in typeToConvert.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite && jsonDocument.RootElement.TryGetProperty(property.Name, out var jsonProperty))
                {
                    var value = JsonSerializer.Deserialize(jsonProperty.GetRawText(), property.PropertyType, options);
                    property.SetValue(instance, value);
                }
            }

            return instance;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            // Use the default serialization behavior
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
