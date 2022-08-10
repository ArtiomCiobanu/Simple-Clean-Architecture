using CleanArchitecture.Application.Features.Users;
using FluentValidation;

namespace CleanArchitecture.Validators
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(u => u.UserId)
                .NotEmpty();
        }
    }
}
