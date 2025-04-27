using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Models.Entities;

namespace TheGamesDBApiWrapper.Models.Responses.Genres
{
    /// <summary>
    /// GenreDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GenreDataModel: Base.DataModel
    {
        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        [JsonPropertyName("genres")]
        public Dictionary<int, GenreModel> Genres { get; set; } = new Dictionary<int, GenreModel>();
    }
}
