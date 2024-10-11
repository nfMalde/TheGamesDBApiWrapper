using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RichardSzalay.MockHttp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Converter;
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
using TheGamesDBApiWrapper.Resolver;

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

        private RestClient mockRestClient<TResponse>(string jsonfile) where TResponse : class
        {
            string content = this.loadJson(jsonfile);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*")
            .Respond("application/json", content);

            string fakeResponse = this.loadJson(jsonfile);
            return new RestClient(new RestClientOptions()
            {
                ConfigureMessageHandler = _ => mockHttp,
                BaseUrl = new Uri("https://localhost/testapi/"),
            },
            configureSerialization: s => s.UseNewtonsoftJson(this.getJsonSettings()));
        }

        private IServiceProvider ServiceProvider;

        private JsonSerializerSettings getJsonSettings()
        {
            var settings = new JsonSerializerSettings();
            //Now Add Converter for all Models that require DI
            settings.ContractResolver = new DIContractResolver(this.ServiceProvider);
            settings.Converters.Add(new DictConverter());

            return settings;
        }

        private void mockServices<TResponse>(string jsonfile) where TResponse : class
        {
            Mock<ITheGamesDBApiWrapperRestClientFactory> mock = new Mock<ITheGamesDBApiWrapperRestClientFactory>();
            mock.Setup(x => x.Create(It.IsAny<string>())).Returns(() => this.mockRestClient<TResponse>(jsonfile));

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f => mock.Object);
            services.AddScoped(f => new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel());
            services.AddScoped<ITheGamesDBAPI, TheGamesDBAPI>();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        #endregion

        #region Tests
        [Test]
        public async Task DeveloperResponseShouldBeParsed()
        {
            this.mockServices<DevelopersResponse>("developer");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();
            var response = await api.Developers.All();

            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Developers.ShouldNotBeNull();
            response.Data.Developers.First().Value.Name.ShouldNotBeNull();
        }

        [TestCaseSource(nameof(GameByIdMocks))]
        public async Task GameByIdResponseShouldBeParsed(string mockfile)
        {
            this.mockServices<GamesByGameIDResponse>(mockfile);

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameID(new int[] { 1, 2, 3, 4, 5 });

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

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();
            var response = await api.Games.Images(new int[] { 1 });

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

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Games.Updates(0);

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

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Platform.All();

            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Platforms.ShouldNotBeNull();
            response.Data.Platforms.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
        public async Task GenresResponseShouldBeParsed()
        {
            this.mockServices<GenresResponse>("genres");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Genres.All();

            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Genres.ShouldNotBeNull();
            response.Data.Genres.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
        public async Task PublishersResponseShouldBeParsed()
        {
            this.mockServices<PublishersResponse>("publishers");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            response.Code.ShouldBeGreaterThan(0);
            response.Data.ShouldNotBeNull();
            response.Data.Publishers.ShouldNotBeNull();
            response.Data.Publishers.First().Value.Name.ShouldNotBeNull();
        }

        [Test]
        public async Task AllowanceShouldBeTracked()
        {
            this.mockServices<PublishersResponse>("publishers");
            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            IAllowanceTracker tracker = this.ServiceProvider.GetService<IAllowanceTracker>();

            tracker.Current.ShouldNotBeNull();
            tracker.Current.Remaining.ShouldBe(2916);
            api.AllowanceTrack.ShouldBeSameAs(tracker.Current);
        }

        #endregion
    }
}