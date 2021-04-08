using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses
{
    /// <summary>
    /// PagesModel
    /// </summary>
    public class PagesModel
    {
        /// <summary>
        /// Gets or sets the previous url.
        /// </summary>
        /// <value>
        /// The previous.
        /// </value>
        [JsonProperty("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Gets or sets the current url.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        [JsonProperty("current")]
        public string Current { get; set; }

        /// <summary>
        /// Gets or sets the next url.
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        [JsonProperty("next")]
        public string Next { get; set; }

    }
}
