using System;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Responses.Utility;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /API Utility Endpoints
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IUtility" />
    public class Utility : Base.BaseApiClass, IUtility
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Utility" /> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Utility(IServiceProvider provider, Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(provider, config, factory, "API", allowanceTracker)
        {
        }

        /// <summary>
        /// Check API key allowance. Does not count against your allowance.
        /// </summary>
        /// <returns></returns>
        public async Task<ApiLimitResponse?> GetApiLimit()
        {
            return await this.CallGet<ApiLimitResponse>("Limit");
        }
    }
}
