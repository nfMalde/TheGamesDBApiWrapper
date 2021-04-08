using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    /// <summary>
    /// GameUpdatePayload
    /// </summary>
    public class GameUpdatePayload
    {
        /// <summary>
        /// Gets or sets the last endit identifier.
        /// </summary>
        /// <value>
        /// The last endit identifier.
        /// </value>
        [DataMember(Name = "last_edit_id")]
        public int LastEnditID { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        [DataMember(Name = "time")]
        public long? Time { get; set; }

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
