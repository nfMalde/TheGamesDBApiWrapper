using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Utility;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Api Wrapper for TheGamesDB Utility Endpoints
    /// </summary>
    public interface IUtility
    {
        /// <summary>
        /// Check API key allowance. Does not count against your allowance.
        /// </summary>
        /// <returns></returns>
        Task<ApiLimitResponse?> GetApiLimit();
    }
}
