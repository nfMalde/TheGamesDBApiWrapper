using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Entities
{

    /// <summary>
    /// ImageBaseUrlMetaModel
    /// </summary>
    public class ImageBaseUrlMetaModel
    {
        /// <summary>
        /// Gets or sets the original size uri.
        /// </summary>
        /// <value>
        /// The original.
        /// </value>
        [JsonProperty("original")]
        public string Original { get; set; }
        /// <summary>
        /// Gets or sets the small size uri.
        /// </summary>
        /// <value>
        /// The small.
        /// </value>
        [JsonProperty("small")]
        public string Small { get; set; }
        /// <summary>
        /// Gets or sets the thumb size uri.
        /// </summary>
        /// <value>
        /// The thumb.
        /// </value>
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
        /// <summary>
        /// Gets or sets the cropped center thumb size uri.
        /// </summary>
        /// <value>
        /// The cropped center thumb.
        /// </value>
        [JsonProperty("cropped_center_thumb")]
        public string CroppedCenterThumb { get; set; }
        /// <summary>
        /// Gets or sets the medium size uri.
        /// </summary>
        /// <value>
        /// The medium.
        /// </value>
        [JsonProperty("medium")]
        public string Medium { get; set; }
        /// <summary>
        /// Gets or sets the lage.
        /// </summary>
        /// <value>
        /// The lage.
        /// </value>
        [JsonProperty("large")]
        public string Lage { get; set; }
    }
}
