namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; init; } = null!;
        public string FullName { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
