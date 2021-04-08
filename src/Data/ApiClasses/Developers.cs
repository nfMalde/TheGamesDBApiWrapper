using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Models.Responses.Developers;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /Developers Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IDevelopers" />
    public class Developers : Base.BaseApiClass, IDevelopers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developers" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        public Developers(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory) : base(config, factory, "Developers")
        {
        }


        /// <summary>
        /// Loads all Developers
        /// </summary>
        /// <returns></returns>
        public async Task<DevelopersResponse> All()
        {
            return await this.CallGet<DevelopersResponse>();
        }

    }
}
