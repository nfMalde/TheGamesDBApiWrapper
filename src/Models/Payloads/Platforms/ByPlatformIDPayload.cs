using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Platforms
{
    /// <summary>
    /// ByPlatformIDPayload
    /// </summary>
    public class ByPlatformIDPayload
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [DataMember(Name = "fields")]
        public string Fields { get; set; }
    }
}
