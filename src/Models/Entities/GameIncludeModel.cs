using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// GameIncludeModel
    /// </summary>
    public class GameIncludeModel
    {
        /// <summary>
        /// Gets or sets the box art.
        /// </summary>
        /// <value>
        /// The box art.
        /// </value>
        [JsonProperty("boxart")]
        public BoxArtIncludeModel BoxArt { get; set; }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        [JsonProperty("platform")]
        public PlatformIncludeModel Platform { get; set; }
    }
}
