using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Responses.Countries;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Api Wrapper for TheGamesDB:/Countries Endpoint
    /// </summary>
    public interface ICountries
    {
        /// <summary>
        /// Loads all Countries
        /// </summary>
        /// <returns></returns>
        Task<CountriesResponse?> All();
    }
}
