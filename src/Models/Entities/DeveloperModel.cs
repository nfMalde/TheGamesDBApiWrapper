using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Entities
{
    /// <summary>
    /// Model for Developer Entity
    /// </summary>
    public class DeveloperModel
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
        public string Name { get; set; } = null!;
    }
}
