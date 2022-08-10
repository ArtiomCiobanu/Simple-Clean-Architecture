using CleanArchitecture.Common.Responses;
using CleanArchitecture.Common.Responses.Enums;

namespace CleanArchitecture.Common.Extensions;

public static class ResponseExtensions
{
    public static IResponse<T> GetResponse<T>(this T result, ResponseStatus status, string? message = null)
        => new Response<T>(status)
        {
            Result = result,
            Message = message
        };

    public static IResponse<T> Success<T>(this T result, string? message = null)
        => result.GetResponse(ResponseStatus.Success, message);

    public static IResponse<T> Forbidden<T>(this T result, string? message = null)
        => result.GetResponse(ResponseStatus.Forbidden, message);

    public static IResponse<T> Unauthorized<T>(this T result, string? message = null)
        => result.GetResponse(ResponseStatus.Unauthorized, message);
}
