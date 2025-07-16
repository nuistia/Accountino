using Accountino.Domain.Common;
using Accountino.Domain.Common.Specification;

namespace Accountino.Application.Interfaces;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(int id);
    Task<List<TEntity>> GetBySpecification(Specification<TEntity> spec);
}
