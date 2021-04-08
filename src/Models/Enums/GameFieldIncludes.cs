using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Models.Enums
{
    /// <summary>
    /// GameFieldIncludes
    /// </summary>
    public enum GameFieldIncludes
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember( Value = "boxart,platform")]
        All,
        /// <summary>
        /// The box art
        /// </summary>
        [EnumMember(Value = "boxart")]
        BoxArt,
        /// <summary>
        /// The platform
        /// </summary>
        [EnumMember( Value = "platform")]
        Platform
    }
}
