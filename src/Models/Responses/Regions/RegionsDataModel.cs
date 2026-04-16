using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Regions
{
    /// <summary>
    /// RegionsDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class RegionsDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        [JsonPropertyName("regions")]
        public Dictionary<int, Entities.RegionModel>? Regions { get; set; }
    }
}
