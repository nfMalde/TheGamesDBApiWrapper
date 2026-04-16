using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Models.Config;

namespace TheGamesDBApiWrapper.Data
{
    public class TheGamesDBApiWrapperRestClientFactory : ITheGamesDBApiWrapperRestClientFactory
    {
        private readonly IServiceProvider provider;
        private readonly TheGamesDBApiConfigModel config;
        private readonly IHttpClientFactory httpClientFactory;
        private HttpMessageHandler? messageHandler = null;

        public TheGamesDBApiWrapperRestClientFactory(IServiceProvider provider, TheGamesDBApiConfigModel config, IHttpClientFactory httpClientFactory)
        {
            this.provider = provider;
            this.config = config;
            this.httpClientFactory = httpClientFactory;
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
            // If a message handler is set (e.g., for testing), use it directly
            var httpClient = this.messageHandler != null 
                ? new HttpClient(this.messageHandler)
                : this.httpClientFactory.CreateClient("TheGamesDB");

            // Set timeout from config
            httpClient.Timeout = TimeSpan.FromSeconds(this.config.HttpTimeout);

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
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)

                }
            };

            // Add custom converters if needed
            

            return options;
        }
    }
}
