using Accountino.Application.Interfaces;
using Accountino.Domain.Common;
using Accountino.Domain.Common.Specification;
using Microsoft.EntityFrameworkCore;

namespace Accountino.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected AccountinoDbContext Context { get; init; }
    private readonly DbSet<TEntity> _entities;

    public Repository(AccountinoDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = Context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _entities.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<List<TEntity>> GetBySpecification(Specification<TEntity> spec)
    {
        IQueryable<TEntity> query = _entities;

        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        foreach (var include in spec.Includes)
            query = query.Include(include);

        return await query.ToListAsync();
    }
}
