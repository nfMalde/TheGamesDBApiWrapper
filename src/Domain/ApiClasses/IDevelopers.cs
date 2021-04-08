using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Developers;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Handles Requests to /Developers Endpoint
    /// </summary>
    public interface IDevelopers
    {
        /// <summary>
        /// Loads all Developers
        /// </summary>
        /// <returns></returns>
        Task<DevelopersResponse> All();
    }
}