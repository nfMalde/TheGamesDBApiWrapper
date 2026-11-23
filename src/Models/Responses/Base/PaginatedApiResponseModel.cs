using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Helper;
using TheGamesDBApiWrapper.Domain.Track;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// PaginatedApiResponseModel
    /// </summary>
    /// <typeparam name="TDataModel">The type of the data model.</typeparam>
    /// <typeparam name="TResponseModel">The type of the response model.</typeparam>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.BaseApiResponseModel{TDataModel}" />
    public abstract class PaginatedApiResponseModel<TDataModel, TResponseModel> : BaseApiResponseModel<TDataModel>
        where TDataModel : class
        where TResponseModel : class, new()
    {
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        [JsonPropertyName("pages")]
        public PagesModel? Pages { get; set; }

        /// <summary>
        /// Loads the previous page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.TheGamesDBApiException">Error fetching next Page by calling {this.Pages.Previous}.</exception>
        public async Task<TResponseModel?> PreviousPage()
        {
            if (string.IsNullOrEmpty(this.Pages?.Previous))
            {
                return null;
            }

            ITheGamesDBApiWrapperRestClientFactory restClientFactory = this.Provider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            var diResolveHelper = this.Provider.GetRequiredService<IDIResolveHelper>();

            using var client = restClientFactory.Create(string.Empty);

            var prevPageResponse = await client.GetAsync(this.Pages.Previous);

            if (prevPageResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var res = await prevPageResponse.Content.ReadFromJsonAsync<TResponseModel>(restClientFactory.GetJsonSerializerOptions());
                diResolveHelper.EnrichViaDI(res);
                this.TrackAllowance(res as BaseApiResponseModel);
                return res;
            }

            string result = await prevPageResponse?.Content?.ReadAsStringAsync()! ?? string.Empty;
            this.TrackAllowance(result, restClientFactory.GetJsonSerializerOptions());

            throw new Exceptions.TheGamesDBApiException($"Error received response {prevPageResponse?.StatusCode} - {result ?? "<no content>"} fetching next Page by calling {this.Pages.Previous}");
        }

        /// <summary>
        /// Loads the next page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.TheGamesDBApiException">Error fetching next Page by calling {this.Pages.Next}.</exception>
        public async Task<TResponseModel?> NextPage()
        {
            if (string.IsNullOrEmpty(this.Pages?.Next))
            {
                return null;
            }

            ITheGamesDBApiWrapperRestClientFactory restClientFactory = this.Provider.GetRequiredService<ITheGamesDBApiWrapperRestClientFactory>();
            var diResolveHelper = this.Provider.GetRequiredService<IDIResolveHelper>();

            using var client = restClientFactory.Create(string.Empty);

            var nextPageResponse = await client.GetAsync(this.Pages.Next);

            if (nextPageResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var res = await nextPageResponse.Content.ReadFromJsonAsync<TResponseModel>(restClientFactory.GetJsonSerializerOptions());

                diResolveHelper.EnrichViaDI(res);
                this.TrackAllowance(res as BaseApiResponseModel);

                return res;
            }

            string result = await nextPageResponse?.Content?.ReadAsStringAsync()! ?? string.Empty;
            this.TrackAllowance(result, restClientFactory.GetJsonSerializerOptions());

            throw new Exceptions.TheGamesDBApiException($"Error received response {nextPageResponse?.StatusCode} - {result ?? "<no content>"} fetching next Page by calling {this.Pages.Next}");
        }

        /// <summary>
        /// Hands a page's allowance to the <see cref="IAllowanceTracker"/>. The first page of a walk
        /// is tracked by the API class that fetched it; the pages fetched from here were not, so a
        /// caller that walked a hundred pages still saw the allowance of the first one.
        /// </summary>
        private void TrackAllowance(BaseApiResponseModel? page)
        {
            if (page == null) return;

            this.Provider?.GetService<IAllowanceTracker>()
                ?.SetAllowance(page.RemainingMonthlyAllowance, page.ExtraAllowance, page.AllowanceRefreshTimer);
        }

        /// <summary>
        /// The same for an error body. A 429 carries the allowance that ran out and the timer until
        /// it refreshes, which is exactly what the caller needs to know at that moment.
        /// </summary>
        private void TrackAllowance(string? body, JsonSerializerOptions options)
        {
            if (string.IsNullOrWhiteSpace(body)) return;

            try
            {
                this.TrackAllowance(JsonSerializer.Deserialize<ErrorResponseModel>(body, options));
            }
            catch (JsonException)
            {
                // Not JSON, or not theirs: nothing to track.
            }
        }

        [DIResolve]
        protected IServiceProvider Provider { get; set; } = null!;
    }
}
