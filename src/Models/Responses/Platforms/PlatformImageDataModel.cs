﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Platforms
{
    /// <summary>
    /// PlatformImageDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class PlatformImageDataModel: Base.DataModel
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        /// 
        [JsonProperty("base_url")]
        public Entities.ImageBaseUrlMetaModel BaseUrl { get; set; }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        [JsonProperty("images")]
        public Dictionary<int, Entities.PlatformImageModel[]> Images { get; set; }
    }
}
