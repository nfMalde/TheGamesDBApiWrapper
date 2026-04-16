using System.Runtime.Serialization;

namespace TheGamesDBApiWrapper.Models.Payloads.Regions
{
    public class ByRegionIDPayload
    {
        [DataMember(Name = "id")]
        public required string Id { get; set; }
    }
}
