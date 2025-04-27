using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Platforms
{
    /// <summary>
    /// PlatformImagePayload
    /// </summary>
    public class PlatformImagePayload
    {
        /// <summary>
        /// Gets or sets the platform identifier.
        /// </summary>
        /// <value>
        /// The platform identifier.
        /// </value>
        [DataMember(Name = "platforms_id")]
        public required string PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "filter[type]")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        [DataMember(Name = "page")]
        public int Page { get; set; } = 1;
    }
}
