using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GameUpdateDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GameUpdateDataModel: Base.DataModel
    {
        /// <summary>
        /// Gets or sets the updates.
        /// </summary>
        /// <value>
        /// The updates.
        /// </value>
        [JsonProperty("updates")]
        public Models.Entities.UpdateModel[] Updates { get; set; }
    }
}
