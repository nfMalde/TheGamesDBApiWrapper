using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Shouldly;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data;
using TheGamesDBApiWrapper.Data.Track;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Enums;
using TheGamesDBApiWrapper.Models.Responses.Developers;
using TheGamesDBApiWrapper.Models.Responses.Games;
using TheGamesDBApiWrapper.Models.Responses.Genres;
using TheGamesDBApiWrapper.Models.Responses.Platforms;
using TheGamesDBApiWrapper.Models.Responses.Publishers;

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

        private MockHttpMessageHandler mockMessageHandler<TResponse>(string jsonfile) where TResponse : class
        { 

            string content = this.loadJson(jsonfile);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*")
            .Respond("application/json", content);
             
            return mockHttp;
        }

        private IServiceProvider ServiceProvider = null!;
         

        private void mockServices<TResponse>(string jsonfile) where TResponse : class
        {
           
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f => new TheGamesDBApiWrapperRestClientFactory(f.GetRequiredService<IServiceProvider>()).WithMessageHandler(mockMessageHandler<TResponse>(jsonfile)));
            services.AddScoped(f => new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel()
            {
                ApiKey = "testkey",
                BaseUrl = "https://localhost/test/api/"
            });
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        #endregion

        #region Tests

        [Test]
        public async Task DeveloperResponseShouldBeParsed()
        {
            this.mockServices<DevelopersResponse>("developer");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Developers.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Developers.ShouldNotBeNull();
            response.Data.Developers.First().Value.Name.ShouldNotBeNull();
        }

        [TestCaseSource(nameof(GameByIdMocks))]
        public async Task GameByIdResponseShouldBeParsed(string mockfile)
        {
            this.mockServices<GamesByGameIDResponse>(mockfile);

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameID(new int[] { 1, 2, 3, 4, 5 });

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Games.ShouldNotBeNull();
            response.Data.Games.First().GameTitle.ShouldNotBeNull();
        }

        public static object[] GameByIdMocks =  {
                        new object[] { "game-by-id" },
                        new object[] { "game-by-id-2" }
                    };

        [Test]
        public async Task GameImagesResponseShouldBeParsed()
        {
            this.mockServices<GamesImagesResponse>("game-images");

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

        [Test]
        public async Task GameUpdateResponseShouldBeParsed()
        {
            this.mockServices<GameUpdateResponse>("game-updates");

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
        }

        [Test]
        public async Task PlatformsResponseShouldBeParsed()
        {
            this.mockServices<PlatformsResponseModel>("platforms");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Platform.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Platforms.ShouldNotBeNull();
            response.Data.Platforms.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
        public async Task GenresResponseShouldBeParsed()
        {
            this.mockServices<GenresResponse>("genres");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Genres.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Genres.ShouldNotBeNull();
            response.Data.Genres.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
        public async Task PublishersResponseShouldBeParsed()
        {
            this.mockServices<PublishersResponse>("publishers");

            ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            response.ShouldNotBeNull();
            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Publishers.ShouldNotBeNull();
            response.Data.Publishers.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
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

        #endregion
    }
}