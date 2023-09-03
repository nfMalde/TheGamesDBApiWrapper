using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;
using TheGamesDBApiWrapper.Converter;
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
 
        public RestClient Create(string baseUri)
        {
            var settings = new JsonSerializerSettings();
            //Now Add Converter for all Models that require DI
            settings.ContractResolver = new DIContractResolver(this.provider);
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new DictConverter());

            RestClient restClient = string.IsNullOrEmpty(baseUri) ? new RestClient(configureSerialization: s => s.UseNewtonsoftJson(settings)) : new RestClient(baseUri, configureSerialization: s => s.UseNewtonsoftJson(settings));
             

            return restClient;
        }
    }
}
