using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TheGamesDBApiWrapper.Models.Entities;

namespace TheGamesDBApiWrapper.Models.Responses.Publishers
{
    /// <summary>
    /// PublishersDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class PublishersDataModel: Base.DataModel
    {
        /// <summary>
        /// Gets or sets the publishers.
        /// </summary>
        /// <value>
        /// The publishers.
        /// </value>
        [JsonProperty("publishers")]
        public Dictionary<int, PublisherModel> Publishers { get; set; }
    }
}
