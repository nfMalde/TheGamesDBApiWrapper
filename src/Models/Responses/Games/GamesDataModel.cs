using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Responses.Games
{
    /// <summary>
    /// GamesDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class GamesDataModel: Base.DataModel
    {
        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        [JsonProperty("games")]
        public Entities.GameModel[] Games { get; set; }

    }
}
