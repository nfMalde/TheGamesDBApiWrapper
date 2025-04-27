using System.Collections.Generic;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Models.Entities;

namespace TheGamesDBApiWrapper.Models.Responses.Platforms
{
    /// <summary>
    /// PlatformsDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class PlatformsDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the platforms.
        /// </summary>
        /// <value>
        /// The platforms.
        /// </value>
        [JsonPropertyName("platforms")]
        public Dictionary<int, PlatformModel>? Platforms { get; set; }
    }
}
