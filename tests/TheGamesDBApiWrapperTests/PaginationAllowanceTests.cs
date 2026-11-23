using Microsoft.Extensions.DependencyInjection;
using RichardSzalay.MockHttp;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Data;
using TheGamesDBApiWrapper.Data.Helper;
using TheGamesDBApiWrapper.Data.Track;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Helper;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Exceptions;
using TheGamesDBApiWrapper.Models.Responses.Games;
using Xunit;

namespace TheGamesDBApiWrapperTests
{
    /// <summary>
    /// The allowance a walk through pages leaves in the tracker. Only the first page used to be
    /// tracked; a caller that walked a hundred pages of updates still saw the first page's number.
    /// </summary>
    public class PaginationAllowanceTests
    {
        private const string NextUrl = "https://localhost/test/api/v1/Games/Updates?page=2";

        private static (IServiceProvider Provider, IAllowanceTracker Tracker) Services(HttpStatusCode status, string body)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IAllowanceTracker, AllowanceTracker>();
            services.AddScoped<IDIResolveHelper, DIResolveHelper>();

            var config = new TheGamesDBApiWrapper.Models.Config.TheGamesDBApiConfigModel
            {
                ApiKey = "testkey",
                BaseUrl = "https://localhost/test/api/",
                HttpTimeout = 180
            };

            services.AddSingleton(config);
            services.AddHttpClient("TheGamesDB");

            services.AddScoped<ITheGamesDBApiWrapperRestClientFactory>(f =>
            {
                var handler = new MockHttpMessageHandler();
                handler.When(NextUrl).Respond(status, "application/json", body);

                return new TheGamesDBApiWrapperRestClientFactory(
                    f.GetRequiredService<IServiceProvider>(),
                    config,
                    f.GetRequiredService<IHttpClientFactory>()
                ).WithMessageHandler(handler);
            });

            var provider = services.BuildServiceProvider();
            return (provider, provider.GetRequiredService<IAllowanceTracker>());
        }

        private static GameUpdateResponse FirstPage(IServiceProvider provider)
        {
            var page = new GameUpdateResponse
            {
                Code = 200,
                RemainingMonthlyAllowance = 900,
                AllowanceRefreshTimer = 800000,
                Pages = new TheGamesDBApiWrapper.Models.Responses.PagesModel { Next = NextUrl },
            };

            // What the API class does to a fetched page: hands it the provider.
            provider.GetRequiredService<IDIResolveHelper>().EnrichViaDI(page);
            return page;
        }

        [Fact]
        public async Task TheNextPageUpdatesTheTracker()
        {
            var (provider, tracker) = Services(HttpStatusCode.OK,
                "{\"code\":200,\"status\":\"Success\",\"data\":{\"count\":0,\"updates\":[]},\"pages\":{\"previous\":null,\"current\":\"x\",\"next\":null},\"remaining_monthly_allowance\":479,\"extra_allowance\":0,\"allowance_refresh_timer\":790000}");

            var next = await FirstPage(provider).NextPage();

            next.ShouldNotBeNull();
            tracker.Current.ShouldNotBeNull();
            tracker.Current!.Remaining.ShouldBe(479);
            tracker.Current.ResetAtSeconds.ShouldBe(790000);
        }

        [Fact]
        public async Task A429WhilePagingIsTrackedBeforeItIsThrown()
        {
            var (provider, tracker) = Services(HttpStatusCode.TooManyRequests,
                "{\"code\":429,\"status\":\"Too Many Requests\",\"remaining_monthly_allowance\":0,\"extra_allowance\":0,\"allowance_refresh_timer\":836913}");

            var ex = await Should.ThrowAsync<TheGamesDBApiException>(() => FirstPage(provider).NextPage());

            ex.Message.ShouldContain("remaining_monthly_allowance");
            tracker.Current.ShouldNotBeNull();
            tracker.Current!.Remaining.ShouldBe(0);
            tracker.Current.ResetAtSeconds.ShouldBe(836913);
        }

        [Fact]
        public async Task AnUnreadableErrorBodyLeavesTheTrackerAlone()
        {
            var (provider, tracker) = Services(HttpStatusCode.BadGateway, "<html>502</html>");

            await Should.ThrowAsync<TheGamesDBApiException>(() => FirstPage(provider).NextPage());

            tracker.Current.ShouldBeNull();
        }
    }
}
