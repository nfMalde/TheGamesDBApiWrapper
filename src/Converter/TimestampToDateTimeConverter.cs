using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Converter
{
    /// <summary>
    /// Converts a Unix timestamp to a DateTime object and vice versa.
    /// </summary>
    internal class TimestampToDateTimeConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Reads and converts the JSON Unix timestamp to a DateTime object.
        /// </summary>
        /// <param name="reader">The Utf8JsonReader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The JsonSerializerOptions.</param>
        /// <returns>A DateTime object.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParse(reader.GetString(), out DateTime result))
            {
                return result;
            }


            throw new Exception($"Token {reader.TokenType} and value {reader.GetString()} is not a valid DateTime.");  
        }

        /// <summary>
        /// Writes a DateTime object as a Unix timestamp to JSON.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter.</param>
        /// <param name="value">The DateTime value to write.</param>
        /// <param name="options">The JsonSerializerOptions.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long timestamp = new DateTimeOffset(value).ToUnixTimeSeconds();
            writer.WriteNumberValue(timestamp);
        }
    }
}
