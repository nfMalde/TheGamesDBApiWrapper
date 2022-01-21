using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data.ApiClasses;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Config;
using TheGamesDBApiWrapper.Models.Track;

namespace TheGamesDBApiWrapper.Data
{
    /// <summary>
    /// API Wrapper for "TheGamesDB" Api
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ITheGamesDBAPI" />
    public class TheGamesDBAPI : ITheGamesDBAPI
    {
        /// <summary>
        /// The allowance tracker
        /// </summary>
        private readonly IAllowanceTracker allowanceTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGamesDBAPI" /> class.
        /// </summary>
        /// <param name="config">The api configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public TheGamesDBAPI(
            TheGamesDBApiConfigModel config, 
            Domain.ITheGamesDBApiWrapperRestClientFactory factory, 
            IAllowanceTracker allowanceTracker)
        {
            //Fix base url and trim
            config.BaseUrl = config.BaseUrl.TrimEnd('/');
            // Create API Classes
            this.Games = new Games(config, factory, allowanceTracker);
            this.Platform = new Platform(config, factory, allowanceTracker);
            this.Genres = new Genres(config, factory, allowanceTracker);
            this.Developers = new Developers(config, factory, allowanceTracker);
            this.Publishers = new Publishers(config, factory, allowanceTracker);
            this.allowanceTracker = allowanceTracker;
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

        /// <summary>
        /// Gets the allowance track 
        /// </summary>
        /// <value>
        /// The allowance track model.
        /// </value>
        public AllowanceTrackModel AllowanceTrack => this.allowanceTracker.Current;

        /// <summary>
        /// Sets the allowance.
        /// </summary>
        /// <param name="remaining">The remaining.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="secondsToReset">The seconds to reset.</param>
        public void SetAllowance(int remaining, int extra, int secondsToReset)
        {
            this.allowanceTracker.SetAllowance(remaining, extra, secondsToReset);
        }


    }
}
