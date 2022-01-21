using System;
using System.Collections.Generic;
using System.Text;

namespace TheGamesDBApiWrapper.Models.Track
{
    public class AllowanceTrackModel
    {
         
        public AllowanceTrackModel(int remaining, int extra, int resetTimer)
        {
            this.Remaining = remaining + extra;
            this.ResetAt = DateTime.Now + TimeSpan.FromSeconds(resetTimer);
        }

        public DateTime ResetAt { get; private set; }
        public int Remaining { get; private set; }
    }
}
