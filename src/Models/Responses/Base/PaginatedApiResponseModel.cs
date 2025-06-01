using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Helper;

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
                return res;
            }

            string result = await prevPageResponse?.Content?.ReadAsStringAsync()! ?? string.Empty;

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
                var res =  await nextPageResponse.Content.ReadFromJsonAsync<TResponseModel>(restClientFactory.GetJsonSerializerOptions());


                diResolveHelper.EnrichViaDI(res);

                return res;
            } 
             

            string result = await nextPageResponse?.Content?.ReadAsStringAsync()!;

            throw new Exceptions.TheGamesDBApiException($"Error received response {nextPageResponse?.StatusCode} - {result ?? "<no content>"} fetching next Page by calling {this.Pages.Next}");
        }

        [DIResolve]
        protected IServiceProvider Provider { get; set; } = null!;
    }
}
