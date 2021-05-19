using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Enums
{
    /// <summary>
    /// GameImageType
    /// </summary>
    [DataContract]
    public enum GameImageType
    {
        /// <summary>
        /// The fanart
        /// </summary>
        [EnumMember(Value = "fanart")]
        Fanart,
        /// <summary>
        /// The banner
        /// </summary>
        [EnumMember(Value = "banner")]
        Banner,
        /// <summary>
        /// The boxart
        /// </summary>
        [EnumMember(Value = "boxart")]
        Boxart,
        /// <summary>
        /// The screenshot
        /// </summary>
        [EnumMember(Value = "screenshot")]
        Screenshot,
        /// <summary>
        /// The clearlogo
        /// </summary>
        [EnumMember(Value = "clearlogo")]
        Clearlogo,
        /// <summary>
        /// The title screen
        /// </summary>
        [EnumMember(Value = "titlescreen")]
        TitleScreen,
        /// <summary>
        /// The icon
        /// </summary>
        [EnumMember(Value = "icon")]
        Icon
    }
}
