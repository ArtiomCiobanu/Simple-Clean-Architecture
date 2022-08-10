using CleanArchitecture.Common.Responses.Enums;

namespace CleanArchitecture.Common.Responses;

public interface IResponse<out TResult> : IResponse
{
    new TResult? Result { get; }
}

public interface IResponse
{
    object? Result { get; }
    ResponseStatus Status { get; }
    string? Message { get; }
}
