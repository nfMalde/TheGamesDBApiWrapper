using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Responses.Genres;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Hanldes Requests to the /Genres Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    public class Genres : Base.BaseApiClass, IGenres
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Genres" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Genres(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(config, factory, "Genres", allowanceTracker)
        {
        }


        /// <summary>
        /// Loads all Genres
        /// </summary>
        /// <returns></returns>
        public async Task<GenresResponse> All()
        {
            return await this.CallGet<GenresResponse>();
        }
    }
}
