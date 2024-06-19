using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly ApiContext _dbContext;
    protected Repository(ApiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
    }
    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }
    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task Adicionar(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        await SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remover(Guid id)
    {
        _dbContext.Set<TEntity>().Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await _dbContext.SaveChangesAsync();
    }


    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
