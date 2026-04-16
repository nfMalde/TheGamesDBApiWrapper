using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data;
using TheGamesDBApiWrapper.Data.Helper;
using TheGamesDBApiWrapper.Data.Track;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Helper;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Enums;
using TheGamesDBApiWrapper.Models.Responses.Developers;
using TheGamesDBApiWrapper.Models.Responses.Games;
using TheGamesDBApiWrapper.Models.Responses.Genres;
using TheGamesDBApiWrapper.Models.Responses.Platforms;
using TheGamesDBApiWrapper.Models.Responses.Publishers;
using Xunit;

namespace TheGamesDBApiWrapperTests
{
    public class ApiTests
    {
        #region Helpers
        private string loadJson(string filename)
        {
            string directory = Directory.GetCurrentDirectory();
            string p = Path.Combine(directory, "json-mocks", filename + ".mock.json");

            if (File.Exists(p))
            {
                return File.ReadAllText(p);
            }

            throw new Exception($"Json Mock {filename}.mock.json not found. Path: {p}");
        }

        private MockHttpMessageHandler mockMessageHandler<TResponse>(string jsonfile, string url) where TResponse : class
        {
            string content = this.loadJson(jsonfile);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(url)
            .Respond("application/json", content);

            return mockHttp;
        }

        private IServiceProvider ServiceProvider = null!;

        private void mockServices<TResponse>(string jsonfile, string url = "") where TResponse : class
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<IDIResolveHelper, DIResolveHelper>();
            
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel()
            {
                ApiKey = "testkey",
                BaseUrl = "https://localhost/test/api/",
                HttpTimeout = 180
            };
            
            services.AddSingleton(config);
            services.AddHttpClient("TheGamesDB");
            
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f =>
            {
                var mockHandler = mockMessageHandler<TResponse>(jsonfile, url);
                var httpClientFactory = f.GetRequiredService<IHttpClientFactory>();
                var factory = new TheGamesDBApiWrapperRestClientFactory(
                    f.GetRequiredService<IServiceProvider>(),
                    config,
                    httpClientFactory
                ).WithMessageHandler(mockHandler);
                return factory;
            });
            
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        #endregion

        #region Tests

        [Fact]
        public async Task DeveloperResponseShouldBeParsed()
        {
            this.mockServices<DevelopersResponse>("developer", "*/v1/Developers");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Developers.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Developers.ShouldNotBeNull();
            response.Data.Developers.First().Value.Name.ShouldNotBeNull();
        }

        [Theory]
        [MemberData(nameof(GameByIdMocks))]
        public async Task GameByIdResponseShouldBeParsed(string mockfile)
        {
            this.mockServices<GamesByGameIDResponse>(mockfile, "*/v1/Games/ByGameID");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameID(new int[] { 1, 2, 3, 4, 5 });

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Games.ShouldNotBeNull();
            response.Data.Games.First().GameTitle.ShouldNotBeNull();
        }

        public static IEnumerable<object[]> GameByIdMocks => new List<object[]>
        {
            new object[] { "game-by-id" },
            new object[] { "game-by-id-2" }
        };

        [Fact]
        public async Task GameImagesResponseShouldBeParsed()
        {
            this.mockServices<GamesImagesResponse>("game-images", "*/v1/Games/Images");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.Images(new int[] { 1 });

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.BaseUrl.ShouldNotBeNull();
            response.Pages.ShouldNotBeNull();
            response.Data.Images.ShouldNotBeNull();
            response.Data.Images.First().Value.First().Type.ShouldNotBeNull();
            response.Data.Images.First().Value.First().Type.ShouldBe(GameImageType.Fanart);
        }

        [Fact]
        public async Task GameUpdateResponseShouldBeParsed()
        {
            this.mockServices<GameUpdateResponse>("game-updates", "*/v1/Games/Updates");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Games.Updates(0); 

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Updates.ShouldNotBeNull();
            response.Data.Updates.First().EditID.ShouldNotBeNull();
            response.Data.Updates.First().GameID.ShouldNotBeNull();
            response.Data.Updates.First().Timestamp.ShouldNotBeNull();
            response.Data.Updates.First().Type.ShouldNotBeNull();
            response.Data.Updates.First().Value.ShouldNotBeNull();
            response.Data.Updates[2].Values!.NumberValue.ShouldBe(1);
            response.Data.Updates[3].Values!.Values!.Length.ShouldBe(1);

        }

        [Fact]
        public async Task PlatformsResponseShouldBeParsed()
        {
            this.mockServices<PlatformsResponseModel>("platforms", "*/v1/Platforms");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Platform.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Platforms.ShouldNotBeNull();
            response.Data.Platforms.First().Value.Name.ShouldNotBeNull();
        }

        [Fact]
        public async Task GenresResponseShouldBeParsed()
        {
            this.mockServices<GenresResponse>("genres", "*/v1/Genres");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Genres.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Genres.ShouldNotBeNull();
            response.Data.Genres.First().Value.Name.ShouldNotBeNull();
        }

        [Fact]
        public async Task PublishersResponseShouldBeParsed()
        {
            this.mockServices<PublishersResponse>("publishers", "*/v1/Publishers");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Publishers.ShouldNotBeNull();
            response.Data.Publishers.First().Value.Name.ShouldNotBeNull();
        }

        [Fact]
        public async Task AllowanceShouldBeTracked()
        {
            this.mockServices<PublishersResponse>("publishers");
            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            IAllowanceTracker tracker = this.ServiceProvider.GetRequiredService<IAllowanceTracker>();

            tracker.Current.ShouldNotBeNull();
            tracker.Current.Remaining.ShouldBe(2916);
            api.AllowanceTrack.ShouldBeSameAs(tracker.Current);
        }

        [Fact]
        public async Task GameById_AllFields_ShouldMatchJson()
        {
            this.mockServices<GamesByGameIDResponse>("game-by-id", "*/v1/Games/ByGameID");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameID(new int[] { 1 }, GameFields.All);

            response.ShouldNotBeNull();
            response.Code.ShouldBe(200);
            response.Data.ShouldNotBeNull();
            response.Data.Games.ShouldNotBeNull();
            response.Data.Games.Length.ShouldBeGreaterThan(0);

            var g = response.Data.Games.First();
            g.Id.ShouldBe(1);
            g.GameTitle.ShouldBe("One");
            g.ReleaseDate.ShouldBe(DateTime.Parse("2003-09-30"));
            g.Platform.ShouldBe(1);
            g.Players.ShouldBe(66);
            g.Overview.ShouldBe("One OV");
            g.LastUpdated.ShouldBe(DateTime.Parse("2021-02-20 14:01:31"));
            g.Rating.ShouldBe("M - Mature 17+");
            g.Coop.ShouldBe("Yes");
            g.YouTube.ShouldBe("dR3Hm8scbEw");
            g.OS.ShouldBe("98SE/ME/2000/XP");
            g.Processor.ShouldBe("733mhz");
            g.RAM.ShouldBe("128 MB");
            g.HDD.ShouldBe("1.2GB");
            g.Video.ShouldBe("32 MB / 3D T&L capable");
            g.Sound.ShouldBeNull();
            g.Developers.ShouldBe(new[] { 1389, 3423 });
            g.Genres.ShouldBe(new[] { 1, 7, 15, 20, 22 });
            // publishers are not present in mock json -> should be default (empty)
            g.Publishers.ShouldNotBeNull();
            g.Publishers.Length.ShouldBe(0);
            // alternates is null in mock json
            g.Alternates.ShouldBeNull();
        }

        [Fact]
        public async Task GameByName_AllFields_ShouldMatchJson()
        {
            this.mockServices<GamesByNameResponse>("game-by-id", "*/v1/Games/ByGameName");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameName("any", 1, GameFields.All);

            response.ShouldNotBeNull();
            response.Code.ShouldBe(200);
            response.Data.ShouldNotBeNull();
            response.Data.Games.ShouldNotBeNull();
            response.Data.Games.Length.ShouldBeGreaterThan(0);

            var g = response.Data.Games.First();
            g.Id.ShouldBe(1);
            g.GameTitle.ShouldBe("One");
            g.ReleaseDate.ShouldBe(DateTime.Parse("2003-09-30"));
            g.Platform.ShouldBe(1);
            g.Players.ShouldBe(66);
            g.Overview.ShouldBe("One OV");
            g.LastUpdated.ShouldBe(DateTime.Parse("2021-02-20 14:01:31"));
            g.Rating.ShouldBe("M - Mature 17+");
            g.Coop.ShouldBe("Yes");
            g.YouTube.ShouldBe("dR3Hm8scbEw");
            g.OS.ShouldBe("98SE/ME/2000/XP");
            g.Processor.ShouldBe("733mhz");
            g.RAM.ShouldBe("128 MB");
            g.HDD.ShouldBe("1.2GB");
            g.Video.ShouldBe("32 MB / 3D T&L capable");
            g.Sound.ShouldBeNull();
            g.Developers.ShouldBe(new[] { 1389, 3423 });
            g.Genres.ShouldBe(new[] { 1, 7, 15, 20, 22 });
            g.Publishers.ShouldNotBeNull();
            g.Publishers.Length.ShouldBe(0);
            g.Alternates.ShouldBeNull();
        }

        [Fact]
        public async Task GameByPlatformId_AllFields_ShouldMatchJson()
        {
            this.mockServices<GameByPlatformIDResponse>("game-by-id", "*/v1/Games/ByPlatformID");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.ByPlatformID(1, GameFields.All);

            response.ShouldNotBeNull();
            response.Code.ShouldBe(200);
            response.Data.ShouldNotBeNull();
            response.Data.Games.ShouldNotBeNull();
            response.Data.Games.Length.ShouldBeGreaterThan(0);

            var g = response.Data.Games.First();
            g.Id.ShouldBe(1);
            g.GameTitle.ShouldBe("One");
            g.ReleaseDate.ShouldBe(DateTime.Parse("2003-09-30"));
            g.Platform.ShouldBe(1);
            g.Players.ShouldBe(66);
            g.Overview.ShouldBe("One OV");
            g.LastUpdated.ShouldBe(DateTime.Parse("2021-02-20 14:01:31"));
            g.Rating.ShouldBe("M - Mature 17+");
            g.Coop.ShouldBe("Yes");
            g.YouTube.ShouldBe("dR3Hm8scbEw");
            g.OS.ShouldBe("98SE/ME/2000/XP");
            g.Processor.ShouldBe("733mhz");
            g.RAM.ShouldBe("128 MB");
            g.HDD.ShouldBe("1.2GB");
            g.Video.ShouldBe("32 MB / 3D T&L capable");
            g.Sound.ShouldBeNull();
            g.Developers.ShouldBe(new[] { 1389, 3423 });
            g.Genres.ShouldBe(new[] { 1, 7, 15, 20, 22 });
            g.Publishers.ShouldNotBeNull();
            g.Publishers.Length.ShouldBe(0);
            g.Alternates.ShouldBeNull();
        }

        [Fact]
        public void HttpTimeout_DefaultValue_ShouldBe180Seconds()
        {
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel();
            config.HttpTimeout.ShouldBe(180);
        }

        [Fact]
        public void HttpTimeout_CanBeConfigured()
        {
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel
            {
                HttpTimeout = 300
            };
            config.HttpTimeout.ShouldBe(300);
        }

        [Fact]
        public void ConfigModel_AllPropertiesHaveDefaults()
        {
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel();
            
            config.BaseUrl.ShouldBe("https://api.thegamesdb.net/");
            config.Version.ShouldBe(1);
            config.ForceVersion.ShouldBe(false);
            config.HttpTimeout.ShouldBe(180);
        }

        [Fact]
        public void RestClientFactory_HttpTimeout_ShouldBeAppliedToHttpClient()
        {
            ServiceCollection services = new ServiceCollection();
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel
            {
                HttpTimeout = 300
            };
            
            services.AddSingleton(config);
            services.AddHttpClient("TheGamesDB");
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f =>
            {
                return new TheGamesDBApiWrapperRestClientFactory(
                    f.GetRequiredService<IServiceProvider>(),
                    config,
                    f.GetRequiredService<IHttpClientFactory>()
                );
            });

            var serviceProvider = services.BuildServiceProvider();
            var factory = serviceProvider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            
            var httpClient = factory.Create("https://example.com");
            
            httpClient.Timeout.ShouldBe(TimeSpan.FromSeconds(300));
        }

        [Fact]
        public void RestClientFactory_WithMessageHandler_ShouldUseMockHandler()
        {
            ServiceCollection services = new ServiceCollection();
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel
            {
                HttpTimeout = 180
            };
            
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.When("*").Respond("application/json", "{}");
            
            services.AddSingleton(config);
            services.AddHttpClient("TheGamesDB");
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f =>
            {
                return new TheGamesDBApiWrapperRestClientFactory(
                    f.GetRequiredService<IServiceProvider>(),
                    config,
                    f.GetRequiredService<IHttpClientFactory>()
                ).WithMessageHandler(mockHandler);
            });

            var serviceProvider = services.BuildServiceProvider();
            var factory = serviceProvider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            
            var httpClient = factory.Create("https://example.com");
            
            // Verify the timeout is still applied
            httpClient.Timeout.ShouldBe(TimeSpan.FromSeconds(180));
            httpClient.BaseAddress?.ToString().ShouldBe("https://example.com/");
        }

        [Fact]
        public void DependencyInjection_AddTheGamesDBApiWrapper_ShouldRegisterAllServices()
        {
            var services = new ServiceCollection();
            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel
            {
                ApiKey = "testkey"
            };
            
            services.AddTheGamesDBApiWrapper(config);
            
            var serviceProvider = services.BuildServiceProvider();
            
            // Verify all services are registered
            var api = serviceProvider.GetRequiredService<ITheGamesDBAPI>();
            var factory = serviceProvider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            var allowanceTracker = serviceProvider.GetRequiredService<IAllowanceTracker>();
            var diResolveHelper = serviceProvider.GetRequiredService<IDIResolveHelper>();
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            
            api.ShouldNotBeNull();
            factory.ShouldNotBeNull();
            allowanceTracker.ShouldNotBeNull();
            diResolveHelper.ShouldNotBeNull();
            httpClientFactory.ShouldNotBeNull();
        }

        [Fact]
        public void DependencyInjection_AddTheGamesDBApiWrapper_WithApiKey_ShouldRegisterAllServices()
        {
            var services = new ServiceCollection();
            services.AddTheGamesDBApiWrapper("myapikey", 1, "https://test.com");
            
            var serviceProvider = services.BuildServiceProvider();
            
            // Verify all services are registered
            var api = serviceProvider.GetRequiredService<ITheGamesDBAPI>();
            var factory = serviceProvider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            
            api.ShouldNotBeNull();
            factory.ShouldNotBeNull();
        }

        #endregion
    }
}
