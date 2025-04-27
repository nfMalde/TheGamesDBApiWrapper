using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses
{
    /// <summary>
    /// PagesModel
    /// </summary>
    public class PagesModel
    {
        /// <summary>
        /// Gets or sets the previous url.
        /// </summary>
        /// <value>
        /// The previous.
        /// </value>
        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        /// <summary>
        /// Gets or sets the current url.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        [JsonPropertyName("current")]
        public string? Current { get; set; }

        /// <summary>
        /// Gets or sets the next url.
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }
}

