using System;
using System.Collections.Generic;
using System.Text;
using TheGamesDBApiWrapper.Domain.Track;

namespace TheGamesDBApiWrapper.Data.Track
{
    /// <summary>
    /// Used to keep track of the monthly allowance.
    /// Use Api->Allowance to get the current
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Domain.Track.IAllowanceTracker" />
    public class AllowanceTracker : IAllowanceTracker
    {
        public AllowanceTracker()
        {

        } 

        public void SetAllowance(int remaining, int extra, int secondsToReset)
        {
            this.Current = new Models.Track.AllowanceTrackModel(remaining, extra, secondsToReset);
        }

        public Models.Track.AllowanceTrackModel? Current { get; private set; }
    }
}
