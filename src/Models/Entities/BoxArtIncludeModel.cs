using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Converter;
using TheGamesDBApiWrapper.Models.Responses.Base;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// BoxArtIncludeModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.IncludeDataModel{TheGamesDBApiWrapper.Models.Entities.GameImageModel}" />
    public class BoxArtIncludeModel
    {
        /// <summary>
        /// Gets or sets the base URL data.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        [JsonPropertyName("base_url")]
        public ImageBaseUrlMetaModel? BaseUrl { get; set; }

        [JsonPropertyName("data"), JsonConverter(typeof(GameImageIncludeDictConverter))]
        public Dictionary<int, GameImageModel[]>? Data { get; set; }

    }
}
