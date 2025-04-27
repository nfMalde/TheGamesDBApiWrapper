using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    /// <summary>
    /// ByGamePlatformIDPayload
    /// </summary>
    public class ByGamePlatformIDPayload
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id")]
        public required string ID { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [DataMember(Name = "fields")]
        public string? Fields { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>
        /// The include.
        /// </value>
        [DataMember(Name = "include")]
        public string? Include { get; set; }

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
