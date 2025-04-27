using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    /// <summary>
    /// GameImagesPayload
    /// </summary>
    public class GameImagesPayload
    {
        /// <summary>
        /// Gets or sets the games identifier.
        /// </summary>
        /// <value>
        /// The games identifier.
        /// </value>
        [DataMember(Name = "games_id")]
        public required string GamesID { get; set; }

        /// <summary>
        /// Gets or sets the type of the filter.
        /// </summary>
        /// <value>
        /// The type of the filter.
        /// </value>
        [DataMember(Name = "filter[type]")]
        public string? FilterType { get; set; }

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
