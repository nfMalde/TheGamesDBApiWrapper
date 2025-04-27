using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Developers
{
    /// <summary>
    /// DevelopersDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class DevelopersDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        /// <value>
        /// The developers.
        /// </value>
        [JsonPropertyName("developers")]
        public Dictionary<int, Entities.DeveloperModel>? Developers { get; set; }
    }
}
