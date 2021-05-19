using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Enums
{
    /// <summary>
    /// PlatformImageType
    /// </summary>
    [DataContract]
    public enum PlatformImageType
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember(Value = "fanart,banner,boxart")]
        All,
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
        /// The boxart
        /// </summary>
        [EnumMember(Value = "icon")]
        Icon
    }
}
