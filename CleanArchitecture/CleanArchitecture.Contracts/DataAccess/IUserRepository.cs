using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.DataAccess;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> ExistsWithEmailAsync(string email);
}
