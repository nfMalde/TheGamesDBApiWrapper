using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// PaginatedApiResponseModel
    /// </summary>
    /// <typeparam name="TDataModel">The type of the data model.</typeparam>
    /// <typeparam name="TResponseModel">The type of the response model.</typeparam>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.BaseApiResponseModel{TDataModel}" />
    public abstract class PaginatedApiResponseModel<TDataModel, TResponseModel>: BaseApiResponseModel<TDataModel> where TDataModel:class where TResponseModel:class, new()
    {

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        [JsonProperty("pages")]
        public PagesModel Pages { get; set; }

        /// <summary>
        /// Loads the previous page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.TheGamesDBApiException">Error fetching next Page by calling {this.Pages.Previous}.</exception>
        public async Task<TResponseModel> PreviousPage()
        {
            if (string.IsNullOrEmpty(this.Pages.Previous))
            {
                return null;
            }

            ITheGamesDBApiWrapperRestClientFactory restClientFactory = this.Provider.GetService<ITheGamesDBApiWrapperRestClientFactory>();

            IRestClient rest = restClientFactory.Create(null);

            IRestResponse<TResponseModel> prevPageResponse = await rest.ExecuteGetAsync<TResponseModel>(new RestRequest(this.Pages.Previous));

            if (prevPageResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return prevPageResponse.Data;
            }

            throw new Exceptions.TheGamesDBApiException($"Error fetching next Page by calling {this.Pages.Previous}.", prevPageResponse.ErrorException);

        }

        /// <summary>
        /// Loads the next page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.TheGamesDBApiException">Error fetching next Page by calling {this.Pages.Next}.</exception>
        public async Task<TResponseModel> NextPage()
        {
            if (string.IsNullOrEmpty(this.Pages.Next))
            {
                return null;
            }
            ITheGamesDBApiWrapperRestClientFactory restClientFactory = this.Provider.GetService<ITheGamesDBApiWrapperRestClientFactory>();

            IRestClient rest = restClientFactory.Create(null);

            IRestResponse<TResponseModel> nextPageResponse = await rest.ExecuteGetAsync<TResponseModel>(new RestRequest(this.Pages.Next));

            if (nextPageResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return nextPageResponse.Data;
            }

            throw new Exceptions.TheGamesDBApiException($"Error fetching next Page by calling {this.Pages.Next}.", nextPageResponse.ErrorException);

        }

        [DIResolve]
        protected IServiceProvider Provider { get; set; }
    }


}
