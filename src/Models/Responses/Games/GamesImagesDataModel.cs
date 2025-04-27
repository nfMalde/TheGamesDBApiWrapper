using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesImagesDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GamesImagesDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        [JsonPropertyName("base_url")]
        public Models.Entities.ImageBaseUrlMetaModel? BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        [JsonPropertyName("images")]
        public Dictionary<int, Models.Entities.GameImageModel[]>? Images { get; set; }
    }
}
