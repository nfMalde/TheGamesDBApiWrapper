using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Publishers;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /Publishers Endpoint
    /// </summary>
    public interface IPublishers
    {
        /// <summary>
        /// Loads all publishers
        /// </summary>
        /// <returns></returns>
        Task<PublishersResponse> All();
    }
}