using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Converter;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Models.Entities;
using TheGamesDBApiWrapper.Resolver;

namespace TheGamesDBApiWrapper.Data
{
    public class TheGamesDBApiWrapperRestClientFactory : ITheGamesDBApiWrapperRestClientFactory
    {
        private readonly IServiceProvider provider;
        private HttpMessageHandler? messageHandler = null;

        public TheGamesDBApiWrapperRestClientFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public TheGamesDBApiWrapperRestClientFactory WithMessageHandler(HttpMessageHandler handler)
        {
            this.messageHandler = handler;

            return this;
        }

        /// <summary>
        /// Creates an HttpClient instance with the specified base URI.
        /// </summary>
        /// <param name="baseUri">The base URI for the HttpClient.</param>
        /// <returns>An HttpClient instance.</returns>
        public HttpClient Create(string baseUri)
        {
            var httpClient = this.messageHandler != null ? new HttpClient(this.messageHandler) : new HttpClient();

            if (!string.IsNullOrEmpty(baseUri))
            {
                httpClient.BaseAddress = new Uri(baseUri);
            }

            return httpClient;
        }

        /// <summary>
        /// Returns the JSON serializer options configured for System.Text.Json.
        /// </summary>
        /// <returns>A JsonSerializerOptions instance.</returns>
        public JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    //new DictConverter<int, GameImageModel[]>()
                }
            };

            // Add custom converters if needed
            

            return options;
        }
    }
}
