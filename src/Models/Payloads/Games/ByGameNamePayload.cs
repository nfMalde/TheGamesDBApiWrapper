using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    /// <summary>
    /// ByGameNamePayload
    /// </summary>
    public class ByGameNamePayload
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [DataMember(Name = "fields")]
        public string Fields { get; set; }

        /// <summary>
        /// Gets or sets the filter platform.
        /// </summary>
        /// <value>
        /// The filter platform.
        /// </value>
        [DataMember(Name = "filter[platform]")]
        public string FilterPlatform { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>
        /// The include.
        /// </value>
        [DataMember(Name = "include")]
        public string Include { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        [DataMember(Name = "page")]
        public int Page { get; set; }
    }
}
