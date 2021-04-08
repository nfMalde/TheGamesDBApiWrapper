using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Entities;

namespace TheGamesDBApiWrapper.Models.Responses.Platforms
{
    /// <summary>
    /// PlatformsDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class PlatformsDataModel: Base.DataModel
    {
        [JsonProperty("platforms")]
        public Dictionary<int, PlatformModel> Platforms { get; set; }
    }
}
