using CleanArchitecture.Common.Responses.Enums;

namespace CleanArchitecture.Common.Responses;

public record class Response<T>(ResponseStatus Status) : IResponse<T>
{
    object? IResponse.Result => Result;

    public T? Result { get; init; }

    public string? Message { get; init; }
}