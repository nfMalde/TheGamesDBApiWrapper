using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data;
using TheGamesDBApiWrapper.Data.Track;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Track;
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
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory, TheGamesDBApiWrapperRestClientFactory>();
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>(factory =>
            {
                IConfiguration config = factory.GetRequiredService<IConfiguration>();
                TheGamesDBApiConfigModel apiConfig = new TheGamesDBApiConfigModel();
                config.GetSection("TheGamesDB").Bind(apiConfig);

                return new TheGamesDBAPI(
                    apiConfig, 
                    factory.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>(),
                    factory.GetRequiredService<IAllowanceTracker>()
                    
                    );
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
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory, TheGamesDBApiWrapperRestClientFactory>();
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>(factory =>
            { 
                return new TheGamesDBAPI(config, 
                    factory.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>(),
                    factory.GetRequiredService<IAllowanceTracker>());
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
        public static IServiceCollection AddTheGamesDBApiWrapper(this IServiceCollection services, string apiKey, double? version = null, string? baseUrl = null)
        {
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
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

                return new TheGamesDBAPI(c, 
                    factory.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>(),
                    factory.GetRequiredService<IAllowanceTracker>());
            });

            return services;
        }
    }
}
