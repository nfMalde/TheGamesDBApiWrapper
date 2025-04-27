using System;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesByNameResponse
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.PaginatedApiResponseModel{TheGamesDBApiWrapper.Models.Responses.Games.GamesDataModel, TheGamesDBApiWrapper.Models.Responses.Games.GamesByNameResponse}" />
    public class GamesByNameResponse : Base.PaginatedApiResponseModel<GamesDataModel, GamesByNameResponse>
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
