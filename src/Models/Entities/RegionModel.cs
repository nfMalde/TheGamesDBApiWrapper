using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Region Model
    /// </summary>
    public class RegionModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
