using CleanArchitecture.Application.Services.Users.Dto;
using FluentValidation;

namespace CleanArchitecture.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(ruc => ruc.Email)
                .EmailAddress() //Using regex would be better here
                .NotEmpty();

            RuleFor(ruc => ruc.FullName)
                .NotEmpty();

            RuleFor(ruc => ruc.Password)
                .NotEmpty();
        }
    }
}
