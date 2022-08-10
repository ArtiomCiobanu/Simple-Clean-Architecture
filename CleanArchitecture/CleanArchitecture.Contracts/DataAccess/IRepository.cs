using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);

        TEntity? ReadById(Guid id);
        Task<TEntity?> ReadByIdAsync(Guid id);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
