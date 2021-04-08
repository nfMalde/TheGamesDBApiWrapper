using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the game title.
        /// </summary>
        /// <value>
        /// The game title.
        /// </value>
        [JsonProperty("game_title")]
        public string GameTitle { get; set; }
        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        [JsonProperty("platform")]
        public int Platform { get; set; }
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        [JsonProperty("players")]
        public int Players { get; set; }
        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonProperty("overview")]
        public string Overview { get; set; }
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [JsonProperty("rating")]
        public string Rating { get; set; }
        /// <summary>
        /// Gets or sets the coop.
        /// </summary>
        /// <value>
        /// The coop.
        /// </value>
        [JsonProperty("coop")]
        public string Coop { get; set; }
        /// <summary>
        /// Gets or sets you tube.
        /// </summary>
        /// <value>
        /// You tube.
        /// </value>
        [JsonProperty("youtube")]
        public string YouTube { get; set; }
        /// <summary>
        /// Gets or sets the os.
        /// </summary>
        /// <value>
        /// The os.
        /// </value>
        [JsonProperty("os")]
        public string OS { get; set; }
        /// <summary>
        /// Gets or sets the processor.
        /// </summary>
        /// <value>
        /// The processor.
        /// </value>
        [JsonProperty("processor")]
        public string Processor { get; set; }
        /// <summary>
        /// Gets or sets the ram.
        /// </summary>
        /// <value>
        /// The ram.
        /// </value>
        [JsonProperty("ram")]
        public string RAM { get; set; }
        /// <summary>
        /// Gets or sets the HDD.
        /// </summary>
        /// <value>
        /// The HDD.
        /// </value>
        [JsonProperty("hdd")]
        public string HDD { get; set; }
        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>
        /// The video.
        /// </value>
        [JsonProperty("video")]
        public string Video { get; set; }
        /// <summary>
        /// Gets or sets the sound.
        /// </summary>
        /// <value>
        /// The sound.
        /// </value>
        [JsonProperty("sound")]
        public string Sound { get; set; }
        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        /// <value>
        /// The developers.
        /// </value>
        [JsonProperty("developers")]
        public int[] Developers { get; set; }
        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        [JsonProperty("genres")]
        public int[] Genres { get; set; }
        /// <summary>
        /// Gets or sets the publishers.
        /// </summary>
        /// <value>
        /// The publishers.
        /// </value>
        [JsonProperty("publishers")]
        public int[] Publishers { get; set; }
        /// <summary>
        /// Gets or sets the alternates.
        /// </summary>
        /// <value>
        /// The alternates.
        /// </value>
        [JsonProperty("alternates")]
        public string[] Alternates { get; set; }
    }
}
