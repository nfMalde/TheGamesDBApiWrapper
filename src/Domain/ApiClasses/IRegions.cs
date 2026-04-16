using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Regions;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Api Wrapper for TheGamesDB:/Regions Endpoint
    /// </summary>
    public interface IRegions
    {
        /// <summary>
        /// Loads all Regions
        /// </summary>
        /// <returns></returns>
        Task<RegionsResponse?> All();

        /// <summary>
        /// Gets Region(s) by ID
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <returns></returns>
        Task<RegionsByIDResponse?> ByRegionID(int regionId);

        /// <summary>
        /// Gets Region(s) by IDs
        /// </summary>
        /// <param name="regionIds">The region identifiers.</param>
        /// <returns></returns>
        Task<RegionsByIDResponse?> ByRegionID(int[] regionIds);
    }
}
