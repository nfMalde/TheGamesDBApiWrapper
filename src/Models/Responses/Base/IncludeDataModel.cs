using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// IncludeDataModel Base Class
    /// </summary>
    /// <typeparam name="TImageModel">The type of the image model.</typeparam>
    public abstract class IncludeDataModel<TImageModel> where TImageModel:class
    {
        [JsonProperty("data")]
        public Dictionary<string, TImageModel[]> Data { get; set; }
    }
}
