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
        /// The icon
        /// </summary>
        [EnumMember(Value = "icon")]
        Icon,
        /// <summary>
        /// The console
        /// </summary>
        [EnumMember(Value = "console")]
        Console,
        /// <summary>
        /// The controller
        /// </summary>
        [EnumMember(Value = "controller")]
        Controller,
        /// <summary>
        /// The developer
        /// </summary>
        [EnumMember(Value = "developer")]
        Developer,
        /// <summary>
        /// The manufacturer
        /// </summary>
        [EnumMember(Value = "manufacturer")]
        Manufacturer,
        /// <summary>
        /// The media
        /// </summary>
        [EnumMember(Value = "media")]
        Media,
        /// <summary>
        /// The cpu
        /// </summary>
        [EnumMember(Value = "cpu")]
        CPU,
        /// <summary>
        /// The memory
        /// </summary>
        [EnumMember(Value = "memory")]
        Memory,
        /// <summary>
        /// The graphics
        /// </summary>
        [EnumMember(Value = "graphics")]
        Graphics,
        /// <summary>
        /// The sound
        /// </summary>
        [EnumMember(Value = "sound")]
        Sound,
        /// <summary>
        /// The max controllers
        /// </summary>
        [EnumMember(Value = "maxcontrollers")]
        MaxControllers,
        /// <summary>
        /// The display
        /// </summary>
        [EnumMember(Value = "display")]
        Display,
        /// <summary>
        /// The overview
        /// </summary>
        [EnumMember(Value = "overview")]
        Overview,
        /// <summary>
        /// The youtube
        /// </summary>
        [EnumMember(Value = "youtube")]
        YouTube
    }
}
