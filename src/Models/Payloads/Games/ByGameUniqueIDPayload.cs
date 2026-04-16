using System.Runtime.Serialization;

namespace TheGamesDBApiWrapper.Models.Payloads.Games
{
    public class ByGameUniqueIDPayload
    {
        [DataMember(Name = "uid")]
        public required string Uid { get; set; }

        [DataMember(Name = "filter[platform]")]
        public string? FilterPlatform { get; set; }

        [DataMember(Name = "fields")]
        public string? Fields { get; set; }

        [DataMember(Name = "include")]
        public string? Include { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }
    }
}
