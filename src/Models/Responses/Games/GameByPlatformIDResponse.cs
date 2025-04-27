using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GameByPlatformIDResponse
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Games.GamesByGameIDResponse" />
    public class GameByPlatformIDResponse : Base.PaginatedApiResponseModel<GamesDataModel, GameByPlatformIDResponse>
    {
        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>
        /// The include.
        /// </value>
        [JsonPropertyName("include")]
        public Models.Entities.GameIncludeModel? Include { get; set; }
    }
}
