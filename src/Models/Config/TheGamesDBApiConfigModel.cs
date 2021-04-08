using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Config
{
    /// <summary>
    /// TheGamesDB Api Config
    /// </summary>
    public class TheGamesDBApiConfigModel
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; set; } = "https://api.thegamesdb.net/";

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public double Version { get; set; } = 1;

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether [force version].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [force version]; otherwise, <c>false</c>.
        /// </value>
        public bool ForceVersion { get; set; } = false;
    }
}
