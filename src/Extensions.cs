using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Models.Config;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TheGamesDBApiWrapperExtensions
    {
        /// <summary>
        /// Adds the games database API wrapper.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddTheGamesDBApiWrapper(this IServiceCollection services)
        {
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory, TheGamesDBApiWrapperRestClientFactory>();
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>(factory =>
            {
                IConfiguration config = factory.GetService<IConfiguration>();
                TheGamesDBApiConfigModel apiConfig = new TheGamesDBApiConfigModel();
                config.GetSection("TheGamesDB").Bind(apiConfig);

                return new TheGamesDBAPI(apiConfig, factory.GetService<ITheGamesDBApiWrapperRestClientFactory>());
            });
             
            return services;
        }


        /// <summary>
        /// Adds the games database API wrapper.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddTheGamesDBApiWrapper(this IServiceCollection services, TheGamesDBApiConfigModel config)
        {
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory, TheGamesDBApiWrapperRestClientFactory>();
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>(factory =>
            { 
                return new TheGamesDBAPI(config, factory.GetService<ITheGamesDBApiWrapperRestClientFactory>());
            });
             
            return services;
        }

        /// <summary>
        /// Adds the games database API wrapper.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="version">The version.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns></returns>
        public static IServiceCollection AddTheGamesDBApiWrapper(this IServiceCollection services, string apiKey, int? version = null, string baseUrl = null)
        {
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory, TheGamesDBApiWrapperRestClientFactory>();
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>(factory =>
            {
                TheGamesDBApiConfigModel c = new TheGamesDBApiConfigModel();
                c.ApiKey = apiKey;
                
                if (baseUrl != null)
                {
                    c.BaseUrl = baseUrl;
                }

                if (version != null)
                {
                    c.Version = version.Value;
                }

                return new TheGamesDBAPI(c, factory.GetService<ITheGamesDBApiWrapperRestClientFactory>());
            });

            return services;
        }
    }
}
