using CleanArchitecture.Application.Features.Users;
using CleanArchitecture.Application.Services.Users;
using CleanArchitecture.Application.Services.Users.Dto;
using CleanArchitecture.ResponseMappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMediator _mediator;
        private readonly IResponseMapper _responseMapper;

        public UserController(
            IUserService userService,
            IMediator mediator,
            IResponseMapper responseMapper)
        {
            _userService = userService;
            _mediator = mediator;
            _responseMapper = responseMapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserDto)
        {
            var response = await _userService.RegisterUser(registerUserDto);

            return _responseMapper.ExecuteAndMapStatus(response);
        }

        [HttpGet("/{userId}/details")]
        public async Task<IActionResult> GetUserDetails(Guid userId)
        {
            var query = new GetUserDetailsQuery(userId);
            var response = await _mediator.Send(query);

            return _responseMapper.ExecuteAndMapStatus(response);
        }
    }
}
