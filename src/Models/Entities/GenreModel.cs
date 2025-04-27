using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Genre Model
    /// </summary>
    public class GenreModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
