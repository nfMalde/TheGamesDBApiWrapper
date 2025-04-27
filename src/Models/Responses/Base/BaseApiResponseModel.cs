using System;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    public abstract class BaseApiResponseModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the remaining monthly allowance.
        /// </summary>
        /// <value>
        /// The remaining monthly allowance.
        /// </value>
        [JsonPropertyName("remaining_monthly_allowance")]
        public int RemainingMonthlyAllowance { get; set; }

        /// <summary>
        /// Gets or sets the extra allowance.
        /// </summary>
        /// <value>
        /// The extra allowance.
        /// </value>
        [JsonPropertyName("extra_allowance")]
        public int ExtraAllowance { get; set; }

        [JsonPropertyName("allowance_refresh_timer")]
        public int AllowanceRefreshTimer { get; set; }
    }

    /// <summary>
    /// Api Response Model Base Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseApiResponseModel<T> : BaseApiResponseModel where T : class
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
