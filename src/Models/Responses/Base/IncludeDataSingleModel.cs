using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// IncludeDataSingleModel
    /// </summary>
    /// <typeparam name="TImageModel">The type of the image model.</typeparam>
    public abstract class IncludeDataSingleModel<TImageModel> where TImageModel : class
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonPropertyName("data")]
        public Dictionary<int, TImageModel>? Data { get; set; }
    }
}
