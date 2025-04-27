using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GamesDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        [JsonPropertyName("games")]
        public Entities.GameModel[] Games { get; set; } = [];
    }
}
