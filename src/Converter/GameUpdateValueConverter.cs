using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapper.Converter
{
    public class GameUpdateValueConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(GameUpdateValueModel));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var valueTypes = token.Children();

                if (valueTypes.Any(x => x.Type == JTokenType.Object))
                {

                    return new GameUpdateValueModel(token.ToObject<Dictionary<string, object>[]>());
                }

                return new GameUpdateValueModel(token.ToObject<object[]>()); 
            } 

            return new GameUpdateValueModel(token.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            GameUpdateValueModel o = value as GameUpdateValueModel;

            if (o != null)
            {
                if (o.Value != null)
                {
                    serializer.Serialize(writer, o.Value); 
                } else
                {
                    serializer.Serialize(writer, o.Values); 
                }

            }
            else 
                serializer.Serialize(writer, null);
        }
    }
}
