using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    public class GameUpdateValueModel
    {
        public GameUpdateValueModel(string value)
        {
            this.Value = value;
        }

        public GameUpdateValueModel(object[] values)
        {
            this.Values = values;
        }

        public GameUpdateValueModel(Dictionary<string, object>[] keyValuePairs)
        {
            this.Objects = keyValuePairs;
        }

         
        public string? Value { get; set; }

        
        public object[]? Values { get; set; }

        public Dictionary<string, object>[]? Objects { get; private set; }
    }
     
}
