using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data.ApiClasses;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Models.Config;

namespace TheGamesDBApiWrapper.Data
{
    /// <summary>
    /// API Wrapper for "TheGamesDB" Api
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ITheGamesDBAPI" />
    public class TheGamesDBAPI : ITheGamesDBAPI
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGamesDBAPI" /> class.
        /// </summary>
        /// <param name="config">The api configuration.</param>
        /// <param name="factory">The factory.</param>
        public TheGamesDBAPI(TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory)
        {
            //Fix base url and trim
            config.BaseUrl = config.BaseUrl.TrimEnd('/');
            // Create API Classes
            this.Games = new Games(config, factory);
            this.Platform = new Platform(config, factory);
            this.Genres = new Genres(config, factory);
            this.Developers = new Developers(config, factory);
            this.Publishers = new Publishers(config, factory);
        }


        /// <summary>
        /// API Endpoint for /Games
        /// </summary>
        /// <value>
        /// The games api client.
        /// </value>
        public IGames Games { get; private set; }

        /// <summary>
        /// API Endpoint for /Platforms
        /// </summary>
        /// <value>
        /// The platform api client.
        /// </value>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// API Endpoint for /Genres
        /// </summary>
        /// <value>
        /// The genres api client.
        /// </value>
        public IGenres Genres { get; private set; }

        /// <summary>
        /// API Endpoint for /Developers
        /// </summary>
        /// <value>
        /// The developers api client.
        /// </value>
        public IDevelopers Developers { get; private set; }

        /// <summary>
        /// API Endpoint for /Publishers
        /// </summary>
        /// <value>
        /// The publishers api client.
        /// </value>
        public IPublishers Publishers { get; private set; }


    }
}
