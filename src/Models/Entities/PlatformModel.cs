using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [JsonProperty("icon")]
        public string  Icon { get; set; }

        /// <summary>
        /// Gets or sets the console.
        /// </summary>
        /// <value>
        /// The console.
        /// </value>
        [JsonProperty("console")]
        public string Console { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        [JsonProperty("controller")]
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets the developer.
        /// </summary>
        /// <value>
        /// The developer.
        /// </value>
        [JsonProperty("developer")]
        public string Developer { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
