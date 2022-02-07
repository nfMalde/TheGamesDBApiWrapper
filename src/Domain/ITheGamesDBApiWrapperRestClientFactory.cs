using RestSharp;

namespace TheGamesDBApiWrapper.Domain
{
    public interface ITheGamesDBApiWrapperRestClientFactory
    {
        RestClient Create(string baseUri);
    }
}