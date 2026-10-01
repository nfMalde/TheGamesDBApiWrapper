using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Models.Entities;

namespace TheGamesDBApiWrapper.Converter
{

    public class GameImageIncludeDictConverter : DictConverter<int, GameImageModel[]>
    {

    }

    /// <summary>
    /// Reads a dictionary that TheGamesDB may send as an empty array. The API is PHP, and PHP's
    /// json_encode writes an empty map as <c>[]</c> instead of <c>{}</c> — e.g. <c>"images": []</c>
    /// when none of the requested games has an image.
    /// </summary>
    /// <remarks>
    /// The object is read entry by entry rather than handed back to <see cref="JsonSerializer"/>:
    /// <see cref="DictConverterFactory"/> registers this converter for every dictionary type, so
    /// delegating would call straight back into it.
    /// </remarks>
    public class DictConverter<TKey, TValue> : JsonConverter<Dictionary<TKey, TValue>>
        where TKey : notnull
    {
        public override Dictionary<TKey, TValue>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;

                case JsonTokenType.StartArray:
                    reader.Read();
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        return new Dictionary<TKey, TValue>();
                    }
                    throw new JsonException($"Expected an object or an empty array for {typeToConvert}, got a non-empty array at byte {reader.TokenStartIndex}.");

                case JsonTokenType.StartObject:
                    return ReadObject(ref reader, options);

                default:
                    throw new JsonException($"Expected an object or an empty array for {typeToConvert}, got {reader.TokenType} at byte {reader.TokenStartIndex}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            var keyConverter = (JsonConverter<TKey>)options.GetConverter(typeof(TKey));

            writer.WriteStartObject();
            foreach (var entry in value)
            {
                keyConverter.WriteAsPropertyName(writer, entry.Key, options);
                JsonSerializer.Serialize(writer, entry.Value, options);
            }
            writer.WriteEndObject();
        }

        private static Dictionary<TKey, TValue> ReadObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            // The key converter turns a property name into TKey the same way the built-in dictionary
            // converter does ("38113" -> 38113 for int keys).
            var keyConverter = (JsonConverter<TKey>)options.GetConverter(typeof(TKey));
            var result = new Dictionary<TKey, TValue>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return result;
                }

                TKey key = keyConverter.ReadAsPropertyName(ref reader, typeof(TKey), options);
                reader.Read();
                result[key] = JsonSerializer.Deserialize<TValue>(ref reader, options)!;
            }

            throw new JsonException($"Unexpected end of JSON while reading {typeof(Dictionary<TKey, TValue>)}.");
        }
    }

    /// <summary>
    /// Applies <see cref="DictConverter{TKey, TValue}"/> to every <see cref="Dictionary{TKey, TValue}"/>
    /// in a response, so any map TheGamesDB returns empty — images, includes, genres, developers,
    /// publishers, platforms, regions, countries — reads as an empty dictionary instead of failing
    /// the whole call.
    /// </summary>
    public class DictConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type converterType = typeof(DictConverter<,>).MakeGenericType(typeToConvert.GetGenericArguments());
            return (JsonConverter?)Activator.CreateInstance(converterType);
        }
    }
}
