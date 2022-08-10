using CleanArchitecture.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.ResponseMappers;

public interface IResponseMapper
{
    IActionResult ExecuteAndMapStatus<TResult>(IResponse<TResult> response);

    Task<IActionResult> ExecuteAndMapStatusAsync<TResult>(IResponse<TResult> response);
    Task<IActionResult> ExecuteAndMapStatusAsync<TResult>(Task<IResponse<TResult>> responseTask);

    object GetMessageResponse<TResult>(IResponse<TResult> response);
}

