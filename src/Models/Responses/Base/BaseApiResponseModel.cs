using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    public class BaseApiResponseModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the remaining monthly allowance.
        /// </summary>
        /// <value>
        /// The remaining monthly allowance.
        /// </value>
        [JsonProperty("remaining_monthly_allowance")]
        public int RemainingMonthlyAllowance { get; set; }

        /// <summary>
        /// Gets or sets the extra allowance.
        /// </summary>
        /// <value>
        /// The extra allowance.
        /// </value>
        [JsonProperty("extra_allowance")]
        public int ExtraAllowance { get; set; }

        [JsonProperty("allowance_refresh_timer")]
        public int AllowanceRefreshTimer { get; set; }
    }

    /// <summary>
    /// Api Response Model Base Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseApiResponseModel<T>: BaseApiResponseModel where T:class
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
