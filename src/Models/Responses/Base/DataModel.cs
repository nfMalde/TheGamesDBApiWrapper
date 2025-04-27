using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// DataModel
    /// </summary>
    public abstract class DataModel
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
