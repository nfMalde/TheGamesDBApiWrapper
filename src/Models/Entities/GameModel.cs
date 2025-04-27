using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Converter;

namespace TheGamesDBApiWrapper.Models.Entities
{

    /// <summary>
    /// Game Model
    /// </summary>
    public class GameModel
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
        /// Gets or sets the game title.
        /// </summary>
        /// <value>
        /// The game title.
        /// </value>
        [JsonPropertyName("game_title")]
        public string? GameTitle { get; set; }
        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [JsonPropertyName("release_date"), JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        [JsonPropertyName("platform")]
        public int? Platform { get; set; }
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        [JsonPropertyName("players")]
        public int? Players { get; set; }
        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonPropertyName("overview")]
        public string? Overview { get; set; }
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        [JsonPropertyName("last_updated"), JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime? LastUpdated { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [JsonPropertyName("rating")]
        public string? Rating { get; set; }
        /// <summary>
        /// Gets or sets the coop.
        /// </summary>
        /// <value>
        /// The coop.
        /// </value>
        [JsonPropertyName("coop")]
        public string? Coop { get; set; }
        /// <summary>
        /// Gets or sets you tube.
        /// </summary>
        /// <value>
        /// You tube.
        /// </value>
        [JsonPropertyName("youtube")]
        public string? YouTube { get; set; }
        /// <summary>
        /// Gets or sets the os.
        /// </summary>
        /// <value>
        /// The os.
        /// </value>
        [JsonPropertyName("os")]
        public string? OS { get; set; }
        /// <summary>
        /// Gets or sets the processor.
        /// </summary>
        /// <value>
        /// The processor.
        /// </value>
        [JsonPropertyName("processor")]
        public string? Processor { get; set; }
        /// <summary>
        /// Gets or sets the ram.
        /// </summary>
        /// <value>
        /// The ram.
        /// </value>
        [JsonPropertyName("ram")]
        public string? RAM { get; set; }
        /// <summary>
        /// Gets or sets the HDD.
        /// </summary>
        /// <value>
        /// The HDD.
        /// </value>
        [JsonPropertyName("hdd")]
        public string? HDD { get; set; }
        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>
        /// The video.
        /// </value>
        [JsonPropertyName("video")]
        public string? Video { get; set; }
        /// <summary>
        /// Gets or sets the sound.
        /// </summary>
        /// <value>
        /// The sound.
        /// </value>
        [JsonPropertyName("sound")]
        public string? Sound { get; set; }
        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        /// <value>
        /// The developers.
        /// </value>
        [JsonPropertyName("developers")]
        public int[] Developers { get; set; } = [];
        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        [JsonPropertyName("genres")]
        public int[] Genres { get; set; } = [];
        /// <summary>
        /// Gets or sets the publishers.
        /// </summary>
        /// <value>
        /// The publishers.
        /// </value>
        [JsonPropertyName("publishers")]
        public int?[] Publishers { get; set; } = [];
        /// <summary>
        /// Gets or sets the alternates.
        /// </summary>
        /// <value>
        /// The alternates.
        /// </value>
        [JsonPropertyName("alternates")]
        public string[] Alternates { get; set; } = [];
    }
}
