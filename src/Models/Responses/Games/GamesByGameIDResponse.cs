using System;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesByGameIDResponse
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.PaginatedApiResponseModel{TheGamesDBApiWrapper.Models.Responses.Games.GamesDataModel, TheGamesDBApiWrapper.Models.Responses.Games.GamesByGameIDResponse}" />
    public class GamesByGameIDResponse : Base.PaginatedApiResponseModel<GamesDataModel, GamesByGameIDResponse>
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
