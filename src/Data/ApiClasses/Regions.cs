using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Payloads.Regions;
using TheGamesDBApiWrapper.Models.Responses.Regions;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /Regions Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IRegions" />
    public class Regions : Base.BaseApiClass, IRegions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Regions" /> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Regions(IServiceProvider provider, Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(provider, config, factory, "Regions", allowanceTracker)
        {
        }

        /// <summary>
        /// Loads all Regions
        /// </summary>
        /// <returns></returns>
        public async Task<RegionsResponse?> All()
        {
            return await this.CallGet<RegionsResponse>();
        }

        /// <summary>
        /// Gets Region(s) by ID
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <returns></returns>
        public async Task<RegionsByIDResponse?> ByRegionID(int regionId)
        {
            return await this.ByRegionID(new int[] { regionId });
        }

        /// <summary>
        /// Gets Region(s) by IDs
        /// </summary>
        /// <param name="regionIds">The region identifiers.</param>
        /// <returns></returns>
        public async Task<RegionsByIDResponse?> ByRegionID(int[] regionIds)
        {
            ByRegionIDPayload payload = new ByRegionIDPayload()
            {
                Id = string.Join(',', regionIds.Select(x => HttpUtility.UrlEncode(x.ToString())))
            };

            return await this.CallGet<RegionsByIDResponse>("GetRegions", payload);
        }
    }
}
