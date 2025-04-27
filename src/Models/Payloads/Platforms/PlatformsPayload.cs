using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Platforms
{
    /// <summary>
    /// PlatformsPayload
    /// </summary>
    public class PlatformsPayload
    {
        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [DataMember(Name = "fields")]
        public string? Fields { get; set; }
    }
}
