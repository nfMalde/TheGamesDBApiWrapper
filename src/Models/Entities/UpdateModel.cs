using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int EditID { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        [JsonProperty("game_id")]
        public int GameID { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
