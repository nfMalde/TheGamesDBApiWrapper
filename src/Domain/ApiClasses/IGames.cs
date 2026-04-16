using System;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Models.Enums;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapper.Domain.ApiClasses
{
    /// <summary>
    /// Api Wrapper for TheGamesDB:/Games Endpoint
    /// </summary>
    public interface IGames
    {
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int gameId, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int gameId, int page, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int gameId, int page, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int gameId, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int[] gameIds, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int[] gameIds, int page, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int[] gameIds, int page, params GameFields[] fields);
        /// <summary>
        /// Gets Game by GameID
        /// </summary>
        /// <param name="gameIds">The game ids.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameID(int[] gameIds, params GameFields[] fields);

        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, GameFieldIncludes[] includes);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int platformId);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int platformId, GameFieldIncludes[] includes);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int platformId, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int platformId, params GameFields[] fields);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int[] platformIds);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="paltformIds">The paltform ids.</param>
        /// <param name="includes">The include fields.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int[] paltformIds, GameFieldIncludes[] includes);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="includes">The include fields.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int[] platformIds, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="platformIds">The platform ids.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, int[] platformIds, params GameFields[] fields);
        /// <summary>
        /// Gets Game or Games by Name
        /// </summary>
        /// <param name="name">The name (query).</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to add in response.</param>
        /// <returns></returns>
        Task<GamesByNameResponse?> ByGameName(string name, int page, params GameFields[] fields);

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID);

        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID, int page);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID, int page, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID, int page, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformID">The platform identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int platformID, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs, int page);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs, int page, GameFieldIncludes[] includes, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs, int page, params GameFields[] fields);
        /// <summary>
        /// Gets platform(s) by platform identifier(s).
        /// </summary>
        /// <param name="platformIDs">The platform identifiers.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Task<GameByPlatformIDResponse?> ByPlatformID(int[] platformIDs, params GameFields[] fields);

        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int gameId);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int gameId, int page);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int gameId, int page, params GameImageType[] types);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int gameId, params GameImageType[] types);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int[] gameIds);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int[] gameIds, int page);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="page">The page.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int[] gameIds, int page, params GameImageType[] types);
        /// <summary>
        /// Gets Image/Images of game(s) by game identifier(s).
        /// </summary>
        /// <param name="gameIds">The game identifiers.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        Task<GamesImagesResponse?> Images(int[] gameIds, params GameImageType[] types);

        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId);
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId, int page = 1);
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId, DateTime time);
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId, DateTime time, int page = 1);
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId, long time);
        /// <summary>
        /// Gets game  updates either by last edit ID (0 for loading all updates) or timestamp offset
        /// </summary>
        /// <param name="lastEditId">The last edit identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<GameUpdateResponse?> Updates(int lastEditId, long time, int page = 1);

        /// <summary>
        /// Gets Game(s) by unique/external identifier (e.g. ROM serial).
        /// </summary>
        /// <param name="uid">The unique ID string.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameUniqueID(string uid, int page = 1, params GameFields[] fields);

        /// <summary>
        /// Gets Game(s) by unique/external identifier, filtered by platform.
        /// </summary>
        /// <param name="uid">The unique ID string.</param>
        /// <param name="platformIds">The platform ids to filter by.</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameUniqueID(string uid, int[]? platformIds, int page = 1, GameFieldIncludes[]? includes = null, params GameFields[] fields);

        /// <summary>
        /// Gets Game(s) by ROM hash.
        /// </summary>
        /// <param name="hash">The hash string.</param>
        /// <param name="page">The page.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameHash(string hash, int page = 1, params GameFields[] fields);

        /// <summary>
        /// Gets Game(s) by ROM hash, filtered by platform and/or hash type.
        /// </summary>
        /// <param name="hash">The hash string.</param>
        /// <param name="platformIds">The platform ids to filter by.</param>
        /// <param name="hashType">The hash type (e.g. "md5", "crc").</param>
        /// <param name="page">The page.</param>
        /// <param name="includes">The include extra fields.</param>
        /// <param name="fields">The fields to show in response.</param>
        /// <returns></returns>
        Task<GamesByGameIDResponse?> ByGameHash(string hash, int[]? platformIds, string? hashType = null, int page = 1, GameFieldIncludes[]? includes = null, params GameFields[] fields);
    }
}