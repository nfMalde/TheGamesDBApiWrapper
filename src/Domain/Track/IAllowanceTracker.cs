using TheGamesDBApiWrapper.Models.Track;

namespace TheGamesDBApiWrapper.Domain.Track
{
    public interface IAllowanceTracker
    {
        AllowanceTrackModel Current { get; }

        void SetAllowance(int remaining, int extra, int secondsToReset);
    }
}