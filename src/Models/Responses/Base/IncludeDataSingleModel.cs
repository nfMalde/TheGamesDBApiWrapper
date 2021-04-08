using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// IncludeDataSingleModel
    /// </summary>
    /// <typeparam name="TImageModel">The type of the image model.</typeparam>
    public abstract class IncludeDataSingleModel<TImageModel> where TImageModel:class
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty("data")]
        public Dictionary<string, TImageModel> Data { get; set; }
    }
}
