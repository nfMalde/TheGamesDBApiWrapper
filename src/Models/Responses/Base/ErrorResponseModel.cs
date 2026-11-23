namespace TheGamesDBApiWrapper.Models.Responses.Base
{
    /// <summary>
    /// An error answer from TheGamesDB: the base fields only. Used to read the allowance off a
    /// non-200 response, which carries it like every other.
    /// </summary>
    public sealed class ErrorResponseModel : BaseApiResponseModel
    {
    }
}
