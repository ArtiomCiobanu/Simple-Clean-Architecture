namespace CleanArchitecture.Application.Services.Users.Dto;

public record class RegisterUserCommand(string Email, string FullName, string Password);

public record class RegisterUserCommandResponse(Guid UserId);
