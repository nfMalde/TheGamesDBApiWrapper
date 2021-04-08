using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
        [JsonProperty("genres")]
        public Dictionary<string, GenreModel> Genres { get; set; }
    }
}
