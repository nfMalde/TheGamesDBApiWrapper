using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Responses.Publishers;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Handles all Requests to the /Publishers Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IPublishers" />
    public class Publishers : Base.BaseApiClass, IPublishers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Publishers" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Publishers(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(config, factory, "Publishers", allowanceTracker)
        {
        }

        /// <summary>
        /// Loads all publishers
        /// </summary>
        /// <returns></returns>
        public async Task<PublishersResponse> All()
        {
            return await this.CallGet<PublishersResponse>();
        }
    }
}
