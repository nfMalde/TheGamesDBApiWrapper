using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Resolver;

namespace TheGamesDBApiWrapper.Data
{
    public class TheGamesDBApiWrapperRestClientFactory : ITheGamesDBApiWrapperRestClientFactory
    {
        private readonly IServiceProvider provider;

        public TheGamesDBApiWrapperRestClientFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }
 
        public IRestClient Create(string baseUri)
        {
            var settings = new JsonSerializerSettings();
            //Now Add Converter for all Models that require DI
            settings.ContractResolver = new DIContractResolver(this.provider);

            IRestClient restClient = string.IsNullOrEmpty(baseUri) ? new RestClient() : new RestClient(baseUri);
            restClient.FailOnDeserializationError = true;
            restClient.ThrowOnAnyError = true;

            restClient.UseNewtonsoftJson(settings);

            return restClient;
        }
    }
}
