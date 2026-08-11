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
            else if (reader.TokenType == JsonTokenType.Number)
            {
                var numberValue = reader.GetInt64();
                return new GameUpdateValueModel(numberValue);

            }
            else if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                // Some edits carry a flag rather than a value. Kept as its literal text so the
                // caller sees what the API actually said instead of a coerced 1/0.
                return new GameUpdateValueModel(reader.GetBoolean() ? "true" : "false");
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                // A single object where the field usually holds a scalar or a list. Wrapped as a
                // one-element dictionary array so it travels through the same shape as the array
                // case rather than needing a fourth representation on the model.
                using (var jsonDocument = JsonDocument.ParseValue(ref reader))
                {
                    var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(
                        jsonDocument.RootElement.GetRawText(), options);

                    if (dictionary == null)
                    {
                        return null;
                    }

                    return new GameUpdateValueModel(new[] { dictionary });
                }
            }

            // Naming the token and where it was found is the whole point: the previous message said
            // only "Unexpected JSON token type.", so a production stack trace could not identify
            // the offending record — and because an exception here aborts the paginated Updates
            // walk before the caller's last-edit cursor advances, every later run replayed the same
            // pages and died on the same value. Undiagnosable and unskippable at once.
            throw new JsonException(
                $"Unexpected JSON token type '{reader.TokenType}' while reading a game update value "
                + $"(at byte {reader.BytesConsumed}). Supported: String, Number, True/False, "
                + "StartArray, StartObject.");
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
