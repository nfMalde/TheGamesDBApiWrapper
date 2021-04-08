using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Enums
{
    /// <summary>
    /// PlatformFields
    /// </summary>
    public enum PlatformFields
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember(Value="icon,console,controller,developer,manufacturer,media,cpu,memory,graphics,sound,maxcontrollers,display,overview,youtube")]
        All,
        /// <summary>
        /// The players
        /// </summary>
        [EnumMember(Value = "players")]
        Players,
        /// <summary>
        /// The publishers
        /// </summary>
        [EnumMember(Value = "publishers")]
        Publishers,
        /// <summary>
        /// The genres
        /// </summary>
        [EnumMember(Value = "genres")]
        Genres,
        /// <summary>
        /// The overview
        /// </summary>
        [EnumMember(Value = "overview")]
        Overview,
        /// <summary>
        /// The last updated
        /// </summary>
        [EnumMember(Value = "last_updated")]
        LastUpdated,
        /// <summary>
        /// The rating
        /// </summary>
        [EnumMember(Value = "rating")]
        Rating,
        /// <summary>
        /// The platform
        /// </summary>
        [EnumMember(Value = "platform")]
        Platform,
        /// <summary>
        /// The coop
        /// </summary>
        [EnumMember(Value = "coop")]
        Coop,
        /// <summary>
        /// The youtube
        /// </summary>
        [EnumMember(Value = "youtube")]
        Youtube,
        /// <summary>
        /// The os
        /// </summary>
        [EnumMember(Value = "os")]
        OS,
        /// <summary>
        /// The processor
        /// </summary>
        [EnumMember(Value = "processor")]
        Processor,
        /// <summary>
        /// The ram
        /// </summary>
        [EnumMember(Value = "ram")]
        RAM,
        /// <summary>
        /// The HDD
        /// </summary>
        [EnumMember(Value = "hdd")]
        HDD,
        /// <summary>
        /// The video
        /// </summary>
        [EnumMember(Value = "video")]
        Video,
        /// <summary>
        /// The sound
        /// </summary>
        [EnumMember(Value = "sound")]
        Sound,
        /// <summary>
        /// The alternates
        /// </summary>
        [EnumMember(Value = "alternates")]
        Alternates
    }
}
