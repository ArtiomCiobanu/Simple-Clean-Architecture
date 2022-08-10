using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DataAccess.Context
{
    public class CleanArchitectureDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options) : base(options)
        {
        }
    }
}
