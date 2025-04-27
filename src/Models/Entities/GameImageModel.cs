using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Enums;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Model for Game Entity
    /// </summary>
    public class GameImageModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonPropertyName("type"), JsonConverter(typeof(JsonStringEnumConverter))]
        public GameImageType? Type { get; set; }
        /// <summary>
        /// Gets or sets the side (i.e. front or back) for boxart images.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [JsonPropertyName("side")]
        public string Side { get; set; } = null!;
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [JsonPropertyName("filename")]
        public string? FileName { get; set; }
        /// <summary>
        /// Gets or sets the resolution.
        /// </summary>
        /// <value>
        /// The resolution.
        /// </value>
        [JsonPropertyName("resolution")]
        public string? Resolution { get; set; }
    }
}
