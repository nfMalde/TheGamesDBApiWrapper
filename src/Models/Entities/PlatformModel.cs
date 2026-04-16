using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Platform Model
    /// </summary>
    public class PlatformModel
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        [JsonPropertyName("alias")]
        public string? Alias { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets the console.
        /// </summary>
        /// <value>
        /// The console.
        /// </value>
        [JsonPropertyName("console")]
        public string? Console { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        [JsonPropertyName("controller")]
        public string? Controller { get; set; }

        /// <summary>
        /// Gets or sets the developer.
        /// </summary>
        /// <value>
        /// The developer.
        /// </value>
        [JsonPropertyName("developer")]
        public string? Developer { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        [JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        [JsonPropertyName("media")]
        public string? Media { get; set; }

        /// <summary>
        /// Gets or sets the cpu.
        /// </summary>
        [JsonPropertyName("cpu")]
        public string? CPU { get; set; }

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        [JsonPropertyName("memory")]
        public string? Memory { get; set; }

        /// <summary>
        /// Gets or sets the graphics.
        /// </summary>
        [JsonPropertyName("graphics")]
        public string? Graphics { get; set; }

        /// <summary>
        /// Gets or sets the sound.
        /// </summary>
        [JsonPropertyName("sound")]
        public string? Sound { get; set; }

        /// <summary>
        /// Gets or sets the max controllers.
        /// </summary>
        [JsonPropertyName("maxcontrollers")]
        public string? MaxControllers { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [JsonPropertyName("display")]
        public string? Display { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        /// <summary>
        /// Gets or sets the youtube.
        /// </summary>
        [JsonPropertyName("youtube")]
        public string? YouTube { get; set; }
    }
}
