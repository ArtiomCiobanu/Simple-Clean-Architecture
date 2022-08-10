using CleanArchitecture.Application.Contracts.DataAccess;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DataAccess.Context;

namespace CleanArchitecture.Infrastructure.DataAccess.Repositories
{
    public class EntityFrameworkBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected CleanArchitectureDbContext Context { get; }

        public EntityFrameworkBaseRepository(CleanArchitectureDbContext context)
        {
            Context = context;
        }

        public void Create(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public TEntity? ReadById(Guid id) => Context.Set<TEntity>().Find(id);

        public Task<TEntity?> ReadByIdAsync(Guid id) => Context.Set<TEntity>().FindAsync(id).AsTask();

        public async Task CreateAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
