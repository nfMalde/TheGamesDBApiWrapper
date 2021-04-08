using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
