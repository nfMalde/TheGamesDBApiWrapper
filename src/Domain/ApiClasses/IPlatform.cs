using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Enums;
using TheGamesDBApiWrapper.Models.Responses.Platforms;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Platform Api Class
    /// Handles all Requests to the Platforms Endpoint of TheGamesDB
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// Gets all Platforms
        /// </summary>
        /// <param name="fields">
        /// The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        /// </returns>
        Task<PlatformsResponseModel?> All(params Models.Enums.PlatformFields[] fields);
        /// <summary>
        /// Gets Platform by ID
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        Task<PlatformsResponseModel?> ByPlatformID(int platformId, params Models.Enums.PlatformFields[] fields);
        /// <summary>
        /// Gets Platforms by ID List
        /// </summary>
        /// <param name="platformIds">The platform identifiers.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        Task<PlatformsResponseModel?> ByPlatformID(int[] platformIds, params Models.Enums.PlatformFields[] fields);
        /// <summary>
        /// Gets Platform Name
        /// </summary>
        /// <param name="name">The platform name to look for.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        Task<PlatformsResponseModel?> ByPlatformName(string name, params Models.Enums.PlatformFields[] fields);
        /// <summary>
        /// Gets a list of images for given platform ids
        /// </summary>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="platformImageTypes">The platform image types as params.</param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformImagesResponse"/>
        Task<PlatformImagesResponse?> Images(int[] platformIds, int page = 1, params PlatformImageType[] platformImageTypes);
    }
}