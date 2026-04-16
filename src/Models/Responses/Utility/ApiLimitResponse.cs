using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Utility
{
    /// <summary>
    /// ApiLimitResponse - response for checking API key allowance.
    /// Note: This response does NOT inherit BaseApiResponseModel because
    /// the API returns a flat object without code/status/data wrapper.
    /// </summary>
    public class ApiLimitResponse
    {
        /// <summary>
        /// Gets or sets the remaining monthly allowance.
        /// </summary>
        [JsonPropertyName("remaining_monthly_allowance")]
        public int RemainingMonthlyAllowance { get; set; }

        /// <summary>
        /// Gets or sets the extra allowance.
        /// </summary>
        [JsonPropertyName("extra_allowance")]
        public int ExtraAllowance { get; set; }

        /// <summary>
        /// Gets or sets the allowance refresh timer (seconds until reset, null for unlimited keys).
        /// </summary>
        [JsonPropertyName("allowance_refresh_timer")]
        public int? AllowanceRefreshTimer { get; set; }
    }
}
