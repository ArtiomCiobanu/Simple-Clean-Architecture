using CleanArchitecture.Application.Services.Users.Dto;
using CleanArchitecture.Common.Responses;

namespace CleanArchitecture.Application.Services.Users;

public interface IUserService
{
    Task<IResponse<RegisterUserCommandResponse>> RegisterUser(RegisterUserCommand registerUserDto);
}
