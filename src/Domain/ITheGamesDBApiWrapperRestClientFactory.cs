using RestSharp;

namespace TheGamesDBApiWrapper.Domain
{
    public interface ITheGamesDBApiWrapperRestClientFactory
    {
        IRestClient Create(string baseUri);
    }
}