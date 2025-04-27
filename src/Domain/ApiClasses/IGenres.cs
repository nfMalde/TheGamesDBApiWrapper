using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Genres;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Handles all Requests to /Genres Endpoint
    /// </summary>
    public interface IGenres
    {
        /// <summary>
        /// Loads all Genres
        /// </summary>
        /// <returns></returns>
        Task<GenresResponse?> All();
    }
}