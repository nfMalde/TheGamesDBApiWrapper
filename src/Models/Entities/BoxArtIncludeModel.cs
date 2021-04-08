using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Base;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// BoxArtIncludeModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.IncludeDataModel{TheGamesDBApiWrapper.Models.Entities.GameImageModel}" />
    public class BoxArtIncludeModel: IncludeDataModel<GameImageModel>
    {
        /// <summary>
        /// Gets or sets the base URL data.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        [JsonProperty("base_url")]
        public ImageBaseUrlMetaModel BaseUrl { get; set; }

    }
}
