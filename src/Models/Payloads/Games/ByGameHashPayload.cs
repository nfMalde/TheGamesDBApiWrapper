using System.Runtime.Serialization;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    public class ByGameHashPayload
    {
        [DataMember(Name = "hash")]
        public required string Hash { get; set; }

        [DataMember(Name = "filter[platform]")]
        public string? FilterPlatform { get; set; }

        [DataMember(Name = "filter[type]")]
        public string? FilterType { get; set; }

        [DataMember(Name = "fields")]
        public string? Fields { get; set; }

        [DataMember(Name = "include")]
        public string? Include { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }
    }
}
