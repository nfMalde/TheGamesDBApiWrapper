using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Payloads.Games;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapper.Data.ApiClasses
{
    /// <summary>
    /// Api Wrapper for TheGamesDB:/Games Endpoint
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Data.ApiClasses.Base.BaseApiClass" />
    /// <seealso cref="TheGamesDBApiWrapper.Domain.ApiClasses.IGames" />
    public class Games : Base.BaseApiClass, IGames
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Games" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public Games(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, IAllowanceTracker allowanceTracker) : base(config, factory, "Games", allowanceTracker)
        {
        }

        #region /ByGameID
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int gameId, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(new int[] { gameId }, 0, null, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int gameId, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(new int[] { gameId }, 0, includes, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int gameId, int page, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(new int[] { gameId }, page, null, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int gameId, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(new int[] { gameId }, page, includes, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int[] gameIds, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(gameIds, 0, null, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int[] gameIds, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(gameIds, 0, includes, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int[] gameIds, int page, params Models.Enums.GameFields[] fields)
        {
            return await this.ByGameID(gameIds, page, null, fields);
        }

        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        public async Task<GamesByGameIDResponse> ByGameID(int[] gameIds, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            ByGameIdPayload payload = new ByGameIdPayload();
            payload.Id = string.Join(',', gameIds.Select(x => HttpUtility.UrlEncode(x.ToString())));

            if (includes != null)
            {
                payload.Include = string.Join(',', includes.Select(x =>  HttpUtility.UrlEncode(this.GetEnumValue(x))));
            }

            payload.Fields = string.Join(',', fields.Select(x => HttpUtility.UrlEncode(this.GetEnumValue(x))));
            payload.Page = page;

            return await this.CallGet<GamesByGameIDResponse>("ByGameID", payload);

        }

        #endregion

        #region /ByGameName
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, null, null, null);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int platformId)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, new int[] { platformId }, null, null);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int[] platformIds)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, platformIds, null, null);

        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, null, null, fields);

        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int platformId, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, new int[] { platformId }, null, fields);

        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int[] platformIds, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, platformIds, null, fields);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, Models.Enums.GameFieldIncludes[] includes)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, null, includes, null);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int platformId, Models.Enums.GameFieldIncludes[] includes)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, new int[] { platformId }, includes, null);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="paltformIds">The paltform ids.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int[] paltformIds, Models.Enums.GameFieldIncludes[] includes)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, paltformIds, includes, null);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        public async Task<GamesByNameResponse> ByGameName(string name, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, null, includes, fields);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int platformId, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, new int[] { platformId }, includes, fields);
        }

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        [GamesDBApiVersion(1.1)]
        public async Task<GamesByNameResponse> ByGameName(string name, int page, int[] platformIds, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByGameName(this.FindCorrectApiVersion(MethodBase.GetCurrentMethod()), name, page, platformIds, includes, fields);

        }

        #endregion

        #region /ByPlatformID

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID)
        {
            return await this.__ByPlatformID(new int[] { platformID }, 1, null, null);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(new int[] { platformID }, 1, null, fields);
        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(new int[] { platformID }, 1, includes, fields);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID, int page)
        {
            return await this.__ByPlatformID(new int[] { platformID }, page, null, null);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID, int page, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(new int[] { platformID }, page, null, fields);
        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int platformID, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(new int[] { platformID }, page, includes, fields);

        }


        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs)
        {
            return await this.__ByPlatformID(platformIDs, 1, null, null);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(platformIDs, 1, null, fields);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(platformIDs, 1, includes, fields);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs, int page)
        {
            return await this.__ByPlatformID(platformIDs, page, null, null);

        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs, int page, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(platformIDs, page, null, fields);
        }

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public async Task<GameByPlatformIDResponse> ByPlatformID(int[] platformIDs, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            return await this.__ByPlatformID(platformIDs, page, includes, fields);
        }

        #endregion


        #region /Images

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int gameId)
        {
            return await this.__Images(new int[] { gameId }, 1);

        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int gameId, int page)
        {
            return await this.__Images(new int[] { gameId }, page);

        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int gameId, params Models.Enums.GameImageType[] types)
        {
            return await this.__Images(new int[] { gameId }, 1, types);

        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int gameId, int page, params Models.Enums.GameImageType[] types)
        {

            return await this.__Images(new int[] { gameId }, page, types);
        }


        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int[] gameIds)
        {

            return await this.__Images(gameIds, 1);
        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int[] gameIds, int page)
        {

            return await this.__Images(gameIds, page);
        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int[] gameIds, params Models.Enums.GameImageType[] types)
        {

            return await this.__Images(gameIds, 1, types);
        }

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public async Task<GamesImagesResponse> Images(int[] gameIds, int page, params Models.Enums.GameImageType[] types)
        {
            return await this.__Images(gameIds, page, types);
        }


        #endregion

        #region /Updates
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId)
        {
            return await this.__Updates(lastEditId);

        }

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId, int page = 1)
        {
            return await this.__Updates(lastEditId, page, null);
        }

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId, DateTime time)
        {
            return await this.__Updates(lastEditId, 1, new DateTimeOffset(time).ToUnixTimeSeconds());
        }

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId, DateTime time, int page = 1)
        {
            return await this.__Updates(lastEditId, page, new DateTimeOffset(time).ToUnixTimeSeconds());

        }

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId, long time)
        {
            return await this.__Updates(lastEditId, 1, time);
        }

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<GameUpdateResponse> Updates(int lastEditId, long time, int page = 1)
        {
            return await this.__Updates(lastEditId, page, time);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        private async Task<GameUpdateResponse> __Updates(int lastEditId = 0, int page = 1, long? time = null)
        {
            GameUpdatePayload payload = new GameUpdatePayload();
            payload.LastEnditID = lastEditId;
            payload.Time = time;
            payload.Page = page;

            return await this.CallGet<GameUpdateResponse>("Updates", payload);

        }

        /// <summary>
        /// Gets Images of a Game
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        private async Task<GamesImagesResponse> __Images(int[] gameIds, int page, params Models.Enums.GameImageType[] types)
        {
            // TODO: Payload

            GameImagesPayload payload = new GameImagesPayload();
            payload.GamesID = string.Join(',', gameIds.Select(x => x.ToString()));
            payload.FilterType = types != null ? string.Join(',', types.Select(x => this.GetEnumValue(x))) : null;
            payload.Page = page < 1 ? 1 : page;

            return await this.CallGet<GamesImagesResponse>("Images", payload);
        }

        /// <summary>
        /// Load games by platform id(s)
        /// </summary>
        /// <param name="platformIDs">The platform i ds.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        private async Task<GameByPlatformIDResponse> __ByPlatformID(int[] platformIDs, int page, Models.Enums.GameFieldIncludes[] includes, params Models.Enums.GameFields[] fields)
        {
            ByGamePlatformIDPayload payload = new ByGamePlatformIDPayload();
            payload.ID = string.Join(',', platformIDs.Select(x => HttpUtility.UrlEncode(x.ToString())));
            payload.Fields = fields != null ? string.Join(',', fields.Select(x => HttpUtility.UrlEncode(this.GetEnumValue(x)))) : null;
            payload.Include = includes != null ? string.Join(',', includes.Select(x => HttpUtility.UrlEncode(this.GetEnumValue(x)))) : null;
            payload.Page = page <= 0 ? 1 : page;

            return await this.CallGet<GameByPlatformIDResponse>("ByPlatformID", payload);
        }

        /// <summary>
        /// Load games by name
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="name">The name.</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        private async Task<GamesByNameResponse> __ByGameName(string version, string name, int page, int[] platformIds, Models.Enums.GameFieldIncludes[] includes, Models.Enums.GameFields[] fields)
        {
            ByGameNamePayload payload = new ByGameNamePayload();
            payload.Name = name;
            payload.Page = page <= 0 ? 1 : page;
            payload.FilterPlatform = platformIds != null ? string.Join(',', platformIds.Select(x => HttpUtility.UrlEncode(x.ToString()))) : null;
            payload.Include = includes != null ? string.Join(',', includes.Select(x => HttpUtility.UrlEncode(this.GetEnumValue(x)))) : null;
            payload.Fields = fields != null ? string.Join(',', fields.Select(x => HttpUtility.UrlEncode(this.GetEnumValue(x)))) : null;


            return await this.CallGet<GamesByNameResponse>("ByGameName", payload, version);
        }

        #endregion


    }
}
