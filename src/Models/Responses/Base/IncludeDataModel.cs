using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TheGamesDBApiWrapper.Converter;

namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// IncludeDataModel Base Class
    /// </summary>
    /// <typeparam name="TImageModel">The type of the image model.</typeparam>
    public abstract class IncludeDataModel<TImageModel> where TImageModel : class
    {
        [JsonPropertyName("data")]
        public Dictionary<int, TImageModel[]>? Data { get; set; }
    }
}
