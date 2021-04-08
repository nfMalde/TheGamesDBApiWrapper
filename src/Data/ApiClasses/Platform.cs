using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Domain.ApiClasses;
namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Platform Api Class
    /// Handles all Requests to the Platforms Endpoint of TheGamesDB
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IPlatform" />
    public class Platform : Base.BaseApiClass, IPlatform
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Platform" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        public Platform(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory) : base(config, factory, "Platforms")
        {
        }

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
        public async Task<Models.Responses.Platforms.PlatformsResponseModel> All(params Models.Enums.PlatformFields[] fields)
        {
            Models.Payloads.Platforms.PlatformsPayload payload = new Models.Payloads.Platforms.PlatformsPayload();
            payload.Fields = fields != null && fields.Any() ? string.Join(',', fields.Select(x => this.GetEnumValue(x))) : null;
             
            return await this.CallGet<Models.Responses.Platforms.PlatformsResponseModel>(payload: payload);
        }

        /// <summary>
        /// Gets Platform by ID
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        public async Task<Models.Responses.Platforms.PlatformsResponseModel> ByPlatformID(int platformId, params Models.Enums.PlatformFields[] fields)
        {
            return await this.ByPlatformID(new int[] { platformId }, fields);
        }


        //// <summary>
        /// Gets Platforms by ID List
        /// </summary>
        /// <param name="platformIds">The platform identifiers.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        public async Task<Models.Responses.Platforms.PlatformsResponseModel> ByPlatformID(int[] platformIds, params Models.Enums.PlatformFields[] fields)
        {
            Models.Payloads.Platforms.ByPlatformIDPayload payload = new Models.Payloads.Platforms.ByPlatformIDPayload();

            string ids = string.Join(',', platformIds.Select(x => x.ToString()));

            payload.Fields = fields.Length > 0 ? string.Join(',', fields.Select(x => this.GetEnumValue(x))) : null;
            payload.Id = ids;

            return await this.CallGet<Models.Responses.Platforms.PlatformsResponseModel>("ByPlatformID", payload);
        }


        /// <summary>
        /// Gets Platform Name
        /// </summary>
        /// <param name="name">The platform name to look for.</param>
        /// <param name="fields"> The fields (optional) to include in response body.
        /// <code>icon, console, controller, developer, manufacturer, media, cpu, memory, graphics, sound, maxcontrollers, display, overview, youtube</code>
        /// </param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformsResponseModel"/>
        public async Task<Models.Responses.Platforms.PlatformsResponseModel> ByPlatformName(string name, params Models.Enums.PlatformFields[] fields)
        {
            Models.Payloads.Platforms.ByPlatformNamePayload payload = new Models.Payloads.Platforms.ByPlatformNamePayload();

            payload.Fields = fields.Length > 0 ? string.Join(',', fields.Select(x => this.GetEnumValue(x))) : null;
            payload.Name = name;

            return await this.CallGet<Models.Responses.Platforms.PlatformsResponseModel>("ByPlatformName", payload);
        }


        /// <summary>
        /// Gets a list of images for given platform ids
        /// </summary>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="platformImageTypes">The platform image types as params.</param>
        /// <exception cref="TheGamesDBApiWrapper.Exceptions.TheGamesDBApiException"></exception>
        /// <returns><see cref="TheGamesDBApiWrapper.Models.Responses.Platforms.PlatformImagesResponse"/>
        public async Task<Models.Responses.Platforms.PlatformImagesResponse> Images(int[] platformIds, int page = 1, params Models.Enums.PlatformImageType[] platformImageTypes)
        {


            string[] filterTypes = platformImageTypes.Select(x => this.GetEnumValue(x)).ToArray();

            Models.Payloads.Platforms.PlatformImagePayload payload = new Models.Payloads.Platforms.PlatformImagePayload();
            payload.PlatformId = string.Join(',', platformIds.Select(x => x.ToString()));
            payload.Page = page;
            payload.Type = filterTypes.Any() ? string.Join(',', filterTypes) : null;

            return await this.CallGet<Models.Responses.Platforms.PlatformImagesResponse>("Images", payload);
        }

    }
}
