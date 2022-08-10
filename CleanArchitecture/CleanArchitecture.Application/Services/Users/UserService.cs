using CleanArchitecture.Application.Contracts.DataAccess;
using CleanArchitecture.Application.Services.Users.Dto;
using CleanArchitecture.Common.Extensions;
using CleanArchitecture.Common.Responses;
using CleanArchitecture.Common.Responses.Enums;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResponse<RegisterUserCommandResponse>> RegisterUser(RegisterUserCommand registerUserDto)
        {
            if (await _userRepository.ExistsWithEmailAsync(registerUserDto.Email))
            {
                return new Response<RegisterUserCommandResponse>(ResponseStatus.Conflict)
                {
                    Message = "This email is already in use."
                };
            }

            var newUser = new User
            {
                Id = new Guid(),

                Email = registerUserDto.Email,
                FullName = registerUserDto.FullName,
                Password = registerUserDto.Password
            };
            await _userRepository.CreateAsync(newUser);

            var response = new RegisterUserCommandResponse(newUser.Id);
            return response.Success();
        }
    }
}
