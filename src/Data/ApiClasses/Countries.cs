using System;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Responses.Countries;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /Countries Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.ICountries" />
    public class Countries : Base.BaseApiClass, ICountries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Countries" /> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Countries(IServiceProvider provider, Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(provider, config, factory, "Countries", allowanceTracker)
        {
        }

        /// <summary>
        /// Loads all Countries
        /// </summary>
        /// <returns></returns>
        public async Task<CountriesResponse?> All()
        {
            return await this.CallGet<CountriesResponse>();
        }
    }
}
