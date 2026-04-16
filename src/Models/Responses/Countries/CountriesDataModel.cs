using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheGamesDBApiWrapper.Models.Responses.Countries
{
    /// <summary>
    /// CountriesDataModel
    /// </summary>
    /// <seealso cref="TheGamesDBApiWrapper.Models.Responses.Base.DataModel" />
    public class CountriesDataModel : Base.DataModel
    {
        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        [JsonPropertyName("countries")]
        public Dictionary<int, Entities.CountryModel>? Countries { get; set; }
    }
}
