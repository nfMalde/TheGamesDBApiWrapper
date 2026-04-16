using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Regions
{
    /// <summary>
    /// RegionsByIDDataModel - data model for fetching regions by ID (returns array)
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class RegionsByIDDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        [JsonPropertyName("regions")]
        public Entities.RegionModel[] Regions { get; set; } = [];
    }
}
