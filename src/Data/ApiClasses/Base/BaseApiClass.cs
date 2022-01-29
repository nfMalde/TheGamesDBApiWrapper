using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain;
using TheGamesDBApiWrapper.Domain.Track;
using TheGamesDBApiWrapper.Models.Responses.Base;
using TheGamesDBApiWrapper.Models.Track;

namespace TheGamesDBApiWrapper.Data.ApiClasses.Base
{
    /// <summary>
    /// Abstracrt Base Class for all API-Subclasses
    /// </summary>
    public abstract class BaseApiClass
    {
        /// <summary>
        /// The client
        /// </summary>
        private RestClient client;
        /// <summary>
        /// The apikey
        /// </summary>
        private string apikey;
        /// <summary>
        /// The base URL
        /// </summary>
        private string baseUrl;
        /// <summary>
        /// The endpoint
        /// </summary>
        private string endpoint;
        /// <summary>
        /// The version
        /// </summary>
        private string version;
        /// <summary>
        /// The factory
        /// </summary>
        private readonly ITheGamesDBApiWrapperRestClientFactory factory;
        /// <summary>
        /// The allowance tracker
        /// </summary>
        private readonly IAllowanceTracker allowanceTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiClass" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="allowanceTracker">The allowance tracker.</param>
        public BaseApiClass(Models.Config.TheGamesDBApiConfigModel config, Domain.ITheGamesDBApiWrapperRestClientFactory factory, string endpoint , IAllowanceTracker allowanceTracker)
        {
            this.factory = factory;
            this.allowanceTracker = allowanceTracker;
            this.parseConfig(config, endpoint);
            this.createClient();
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
                this.createClient();
            }
        }

        /// <summary>
        /// If true no version matching is done. Api calls will  call selected version not matter if its supported or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [force version]; otherwise, <c>false</c>.
        /// </value>
        public bool ForceVersion { get; set; }
         

        /// <summary>
        /// Creates the rest client.
        /// </summary>
        private void createClient()
        {
            this.client = this.factory.Create($"{this.baseUrl}/{"{version}"}/{this.endpoint}");
             
            this.client.AddDefaultUrlSegment("version", this.version);
            this.client.AddDefaultQueryParameter("apikey", apikey);
        }

        private void parseConfig(Models.Config.TheGamesDBApiConfigModel config, string endpoint)
        {
            string version = $"v{config.Version}";
            //Fix base url and trim
            config.BaseUrl = config.BaseUrl.TrimEnd('/');

            this.apikey = config.ApiKey;
            this.baseUrl = config.BaseUrl;
            this.endpoint = endpoint;
            this.version = version;
            this.ForceVersion = config.ForceVersion;

        }

        /// <summary>
        /// Gets the enum value how it should be in request params.
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected string GetEnumValue<T>(T value) where T : Enum
        {
            return value.GetType().GetTypeInfo()
                                   .DeclaredMembers
                                   .SingleOrDefault(x => x.Name == value.ToString())
                                   ?.GetCustomAttribute<EnumMemberAttribute>(false)
                                   ?.Value;
        }


        /// <summary>
        /// Finds the correct API version.
        /// If Endpoint Supports  Version 1.1, 1.2, 1.3  the latest version is used.
        /// If Api class is for example set to version  1    Version 1.3 is used.
        /// If Api Class is set to version 1.3 api class will force this version. Somehow TheGamesDB does not downgrade version, instead it results in an 404 if an version is not found / supported.
        /// Work Arround for this is to set it to the desired version right before you call the request and set it back afterwards.
        /// If you dont want to use minor version set "ForceVersion" in  config to true
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        protected string FindCorrectApiVersion(MethodBase method)
        {
            GamesDBApiVersionAttribute[] v = method.GetCustomAttributes<GamesDBApiVersionAttribute>()?.OrderByDescending(x => x.Version).ToArray();

            if (!this.ForceVersion && v != null && v.Any())
            {
                string newVersion = v.Select(x => $"v{x}").FirstOrDefault(x => x.StartsWith(this.Version)) ?? this.version;

                return newVersion;
            }

            return version;
        }

        /// <summary>
        /// Executes the actual get requests
        /// </summary>
        /// <typeparam name="T">ResponseType</typeparam>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error in rest call: {restResponse.ErrorMessage} with response raw data \"{restResponse.Content}\"</exception>
        /// <exception cref="Exceptions.TheGamesDBApiException"></exception>
        protected async Task<T> CallGet<T>(string endpoint = null, object payload = null, string version = null) where T:class
        {
            RestRequest r = new RestRequest(endpoint, Method.Get);

            // Support for long requests
            r.Timeout = 3600;
            

            if (version != null)
            {
                r.AddUrlSegment("version", version);
            }

            if (payload != null)
            {
                Type t = payload.GetType();

                PropertyInfo[] properties = t.GetProperties();
                
                foreach(PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    DataMemberAttribute dataMember = prop.GetCustomAttribute<DataMemberAttribute>();

                    if (dataMember != null)
                    {
                        name = dataMember.Name ?? name;
                    }
                     

                    r.AddQueryParameter(name.Trim(), prop.GetValue(payload)?.ToString() ?? null);
                }
            }

            try
            {
                var restResponse = await this.client.ExecuteGetAsync<T>(r);
                var restResponseBase = restResponse.Data as BaseApiResponseModel;

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    this.allowanceTracker.SetAllowance(restResponseBase.RemainingMonthlyAllowance, restResponseBase.ExtraAllowance, restResponseBase.AllowanceRefreshTimer);
                    return restResponse.Data;
                } 
                else if (restResponse.StatusCode == System.Net.HttpStatusCode.Forbidden && restResponseBase != null)
                {
                    this.allowanceTracker.SetAllowance(restResponseBase.RemainingMonthlyAllowance, restResponseBase.ExtraAllowance, restResponseBase.AllowanceRefreshTimer);
                     
                    throw new Exception($"Error: ApiKey Invalid or reached monthly limit: {this.allowanceTracker.Current.Remaining} remaining, reset at: {this.allowanceTracker.Current.ResetAt}");

                }

                throw new Exception($"Error in rest call: {restResponse.ErrorMessage} with response raw data \"{restResponse.Content}\"");

            }
            catch (Exception e)
            {
                string requestUri =  "/" + endpoint;
                var p = r.Parameters.Select(x => $"{x.Name} = <{x.Value}>");

                string message = $"TheGamesDB Api Error. Unable to send Data {string.Join(';', p)} to endpoint {requestUri}. ";
                message += "See Inner-Exception for details.";

                throw new Exceptions.TheGamesDBApiException(message, e); 
            } 
        }



    }
}
