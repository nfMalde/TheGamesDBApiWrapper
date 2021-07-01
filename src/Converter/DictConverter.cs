using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheGamesDBApiWrapper.Converter
{
    /// <summary>
    /// Since TheGamesDB sends empty objects as empty arrays, we need to convert them.
    /// Based on https://stackoverflow.com/a/26726667
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class DictConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            bool isDict = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
            return isDict;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite { get { return false; } }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <exception cref="JsonSerializationException">
        /// Non-empty JSON array does not make a valid Dictionary!
        /// or
        /// Unexpected token!
        /// </exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();

                if (reader.TokenType == JsonToken.EndArray)
                    return Activator.CreateInstance(objectType);
                else
                    throw new JsonSerializationException("Non-empty JSON array does not make a valid Dictionary!");
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                JToken token = JToken.Load(reader);
                return token.ToObject(objectType); 
            }
            else
            {
                throw new JsonSerializationException("Unexpected token!");
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
