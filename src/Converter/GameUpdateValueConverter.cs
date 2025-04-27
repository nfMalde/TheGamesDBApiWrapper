using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapper.Converter
{
    public class GameUpdateValueConverter : JsonConverter<GameUpdateValueModel>
    {
        public override GameUpdateValueModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Deserialize as an array
                using (var jsonDocument = JsonDocument.ParseValue(ref reader))
                {
                    var array = jsonDocument.RootElement.EnumerateArray().ToList();

                    if (array.Any(x => x.ValueKind == JsonValueKind.Object))
                    {
                        // If any element is an object, deserialize as an array of dictionaries
                        var dictionaries = JsonSerializer.Deserialize<Dictionary<string, object>[]>(jsonDocument.RootElement.GetRawText(), options);

                        if (dictionaries == null)
                        {
                            return null;
                        }

                        return new GameUpdateValueModel(dictionaries);
                    }

                    // Otherwise, deserialize as an array of objects
                    var objects = JsonSerializer.Deserialize<object[]>(jsonDocument.RootElement.GetRawText(), options);

                    if (objects == null)
                    {
                        return null;
                    }

                    return new GameUpdateValueModel(objects);
                }
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                // Deserialize as a string
                var stringValue = reader.GetString();

                if (stringValue == null)
                {
                    return null;
                }

                return new GameUpdateValueModel(stringValue);
            }

            throw new JsonException("Unexpected JSON token type.");
        }

        public override void Write(Utf8JsonWriter writer, GameUpdateValueModel value, JsonSerializerOptions options)
        {
            if (value.Value != null)
            {
                // Serialize the single value
                JsonSerializer.Serialize(writer, value.Value, options);
            }
            else if (value.Values != null)
            {
                // Serialize the array of values
                JsonSerializer.Serialize(writer, value.Values, options);
            }
            else
            {
                // Serialize as null
                writer.WriteNullValue();
            }
        }
    }
}
