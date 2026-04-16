using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Country Model
    /// </summary>
    public class CountryModel
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
