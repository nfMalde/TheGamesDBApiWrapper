using TheGamesDBApiWrapper.Domain.ApiClasses;
using TheGamesDBApiWrapper.Models.Track;

namespace TheGamesDBApiWrapper.Domain
{
    /// <summary>
    /// Api Wrapper for "TheGamesDB" Api
    /// </summary>
    public interface ITheGamesDBAPI
    {
        /// <summary>
        /// API Endpoint for /Games
        /// </summary>
        /// <value>
        /// The games api client.
        /// </value>
        IGames Games { get; }
        /// <summary>
        ///  API Endpoint for /Platforms
        /// </summary>
        /// <value>
        /// The platform api client.
        /// </value>
        IPlatform Platform { get; }
        /// <summary>
        /// API Endpoint for /Genres
        /// </summary>
        /// <value>
        /// The genres api client.
        /// </value>
        IGenres Genres { get; }
        /// <summary>
        /// API Endpoint for /Developers
        /// </summary>
        /// <value>
        /// The developers api client.
        /// </value>
        IDevelopers Developers { get; }
        /// <summary>
        /// API Endpoint for /Publishers
        /// </summary>
        /// <value>
        /// The publishers api client.
        /// </value>
        IPublishers Publishers { get; }

        /// <summary>
        /// Gets the allowance track.
        /// </summary>
        /// <value>
        /// The allowance track model.
        /// </value>
        AllowanceTrackModel AllowanceTrack { get; }

        /// <summary>
        /// Sets the allowance.
        /// </summary>
        /// <param name="remaining">The remaining.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="secondsToReset">The seconds to reset.</param>
        void SetAllowance(int remaining, int extra, int secondsToReset);
    }
}