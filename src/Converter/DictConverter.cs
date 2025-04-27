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
    /// Custom converter to handle cases where TheGamesDB sends empty objects as empty arrays.
    /// </summary>
    public class DictConverter<TKey, TValue> : JsonConverter<Dictionary<TKey, TValue>>
        where TKey : notnull
    {
        public override Dictionary<TKey, TValue>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Handle empty array as an empty dictionary
                reader.Read();
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return new Dictionary<TKey, TValue>();
                }
                else
                {
                    throw new JsonException("Non-empty JSON array does not make a valid Dictionary!");
                }
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                // Deserialize the object as a dictionary
                return JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
            }
            else
            {
                throw new JsonException("Unexpected token!");
            }
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            // Serialize the dictionary as a JSON object
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
