using System.Net.Http;
using System.Text.Json;

namespace TheGamesDBApiWrapper.Domain
{
    public interface ITheGamesDBApiWrapperRestClientFactory
    {
        HttpClient Create(string baseUri);
        JsonSerializerOptions GetJsonSerializerOptions();
    }
}