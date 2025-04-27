using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GameUpdateDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GameUpdateDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the updates.
        /// </summary>
        /// <value>
        /// The updates.
        /// </value>
        [JsonPropertyName("updates")]
        public Models.Entities.UpdateModel[] Updates { get; set; } = [];
    }
}
