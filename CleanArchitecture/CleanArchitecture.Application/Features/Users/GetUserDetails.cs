using AutoMapper;
using CleanArchitecture.Application.Contracts.DataAccess;
using CleanArchitecture.Common.Extensions;
using CleanArchitecture.Common.Responses;
using CleanArchitecture.Common.Responses.Enums;
using MediatR;

namespace CleanArchitecture.Application.Features.Users
{
    public record class GetUserDetailsQuery(Guid UserId) : IRequest<IResponse<GetUserDetailsResponse>>;
    public record class GetUserDetailsResponse(string FullName, string Email);

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, IResponse<GetUserDetailsResponse>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<GetUserDetailsResponse>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReadByIdAsync(request.UserId);

            return user == null
                ? new Response<GetUserDetailsResponse>(ResponseStatus.Conflict) { Message = "No user with specified id was found." }
                : _mapper.Map<GetUserDetailsResponse>(user).Success();
        }
    }
}
