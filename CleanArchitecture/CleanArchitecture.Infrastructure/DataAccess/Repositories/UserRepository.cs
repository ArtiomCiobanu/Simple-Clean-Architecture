using CleanArchitecture.Application.Contracts.DataAccess;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : EntityFrameworkBaseRepository<User>, IUserRepository
    {
        public UserRepository(CleanArchitectureDbContext context) : base(context)
        {
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return Context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<bool> ExistsWithEmailAsync(string email)
        {
            return Context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
