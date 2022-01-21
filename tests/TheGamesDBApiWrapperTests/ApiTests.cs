using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
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

        private Mock<IRestClient> mockRestClient<TResponse>(string jsonfile) where TResponse:class
        {
            string fakeResponse = this.loadJson(jsonfile);

            Mock<IRestClient> restMock = new Mock<IRestClient>();
            restMock.Setup(x => x.DefaultParameters).Returns(() => new List<RestSharp.Parameter>());
            restMock.Setup(x => x.ExecuteGetAsync<TResponse>(It.IsAny<RestRequest>(), default))
                            .Returns(() =>
                            {
                                IRestResponse<TResponse> response = new RestResponse<TResponse>();
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                                response.Data = JsonConvert.DeserializeObject<TResponse>(fakeResponse, this.getJsonSettings());

                                return Task.FromResult(response);
                            });
            return restMock;

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


        private void mockServices<TResponse>(string jsonfile) where TResponse:class
        {
           
            Mock<ITheGamesDBApiWrapperRestClientFactory> mock = new Mock<ITheGamesDBApiWrapperRestClientFactory>();
            mock.Setup(x => x.Create(It.IsAny<string>())).Returns(() => this.mockRestClient<TResponse>(jsonfile).Object);

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

            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Developers);
            Assert.NotNull(response.Data.Developers.First().Value.Name); 
        }

        [TestCaseSource(nameof(GameByIdMocks))]
        public async Task GameByIdResponseShouldBeParsed(string mockfile)
        {
            this.mockServices<GamesByGameIDResponse>(mockfile);

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();
            var response = await api.Games.ByGameID(new int[] { 1,2,3,4,5});

            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Games);
            Assert.NotNull(response.Data.Games.First().GameTitle);
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
            var response = await api.Games.Images(new int[] { 1});

            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.BaseUrl);
            Assert.NotNull(response.Pages);
            Assert.NotNull(response.Data.Images);
            Assert.NotNull(response.Data.Images.First().Value.First().Type);
            Assert.AreEqual(response.Data.Images.First().Value.First().Type, GameImageType.Fanart);

        }

        [Test]
        public async Task GameUpdateResponseShouldBeParsed()
        {
            this.mockServices<GameUpdateResponse>("game-updates");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Games.Updates(0);

            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Updates);
            Assert.NotNull(response.Data.Updates.First().EditID);
            Assert.NotNull(response.Data.Updates.First().GameID);
            Assert.NotNull(response.Data.Updates.First().Timestamp);
            Assert.NotNull(response.Data.Updates.First().Type);
            Assert.NotNull(response.Data.Updates.First().Value);


        }

        [Test]
        public async Task PlatformsResponseShouldBeParsed()
        {
            this.mockServices<PlatformsResponseModel>("platforms");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Platform.All();

            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Platforms);
            Assert.NotNull(response.Data.Platforms.First().Value.Name);

        }

        [Test]
        public async Task GenresResponseShouldBeParsed()
        {
            this.mockServices<GenresResponse>("genres");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Genres.All();


            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Genres);
            Assert.NotNull(response.Data.Genres.First().Value.Name);
        }

        [Test]
        public async Task PublishersResponseShouldBeParsed()
        {
            this.mockServices<PublishersResponse>("publishers");

            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();


            Assert.NotNull(response.Code);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.Publishers);
            Assert.NotNull(response.Data.Publishers.First().Value.Name);
        }

        [Test]
        public async Task AllowanceShouldBeTracked()
        {
            this.mockServices<PublishersResponse>("publishers");
            ITheGamesDBAPI api = this.ServiceProvider.GetService<ITheGamesDBAPI>();

            var response = await api.Publishers.All();

            IAllowanceTracker tracker = this.ServiceProvider.GetService<IAllowanceTracker>();

            Assert.NotNull(tracker.Current);
            Assert.AreEqual(2916, tracker.Current.Remaining);
            Assert.AreSame(api.AllowanceTrack, tracker.Current);
        }

        #endregion

    }
}