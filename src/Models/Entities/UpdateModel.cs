using System;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Converter;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Update Model
    /// </summary>
    public class UpdateModel
    {
        /// <summary>
        /// Gets or sets the edit identifier.
        /// </summary>
        /// <value>
        /// The edit identifier.
        /// </value>
        [JsonPropertyName("edit_id")]
        public int? EditID { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        [JsonPropertyName("game_id")]
        public int? GameID { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonPropertyName("timestamp"), JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the value if value is string.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonPropertyName("value")]
        [JsonConverter(typeof(GameUpdateValueConverter))]
        public GameUpdateValueModel? Values { get; set; }

        /// <summary>
        /// For Backwards Compatibl. this returns the string value only
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonIgnore]
        public string? Value { get { return this.Values?.Value; } }
    }
}
