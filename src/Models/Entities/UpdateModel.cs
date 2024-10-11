using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [JsonProperty("edit_id")]
        public int? EditID { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        [JsonProperty("game_id")]
        public int? GameID { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the value if value is string.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        [JsonConverter(typeof(GameUpdateValueConverter))]
        public GameUpdateValueModel Values { get; set; }

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
