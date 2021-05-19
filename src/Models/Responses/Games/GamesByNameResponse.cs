using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesByNameResponse
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Games.GamesByGameIDResponse" />
    public class GamesByNameResponse : Base.PaginatedApiResponseModel<GamesDataModel, GamesByNameResponse>
    {
        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>
        /// The include.
        /// </value>
        [JsonProperty("include")]
        public Models.Entities.GameIncludeModel Include { get; set; }

    }
}
