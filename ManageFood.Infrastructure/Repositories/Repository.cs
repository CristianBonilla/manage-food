using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ManageFood.Contracts.Repository;

namespace ManageFood.Infrastructure.Repositories
{
  public class Repository<TContext, TEntity>(IRepositoryContext<TContext> context) : IRepository<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class
  {
    readonly DbSet<TEntity> _entitySet = context.Set<TEntity>();
    readonly Func<TEntity, EntityEntry<TEntity>> _entityEntry = entity => context.Entry(entity);

    public TEntity Create(TEntity entity) => _entitySet.Add(entity).Entity;

    public IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
    {
      return Range();

      IEnumerable<TEntity> Range()
      {
        foreach (TEntity entity in entities)
          yield return Create(entity);
      }
    }

    public TEntity Update(TEntity entity)
    {
      var entry = _entityEntry(entity);
      if (entry.State == EntityState.Detached)
        _entitySet.Attach(entity);
      var updated = _entitySet.Update(entity);

      return updated.Entity;
    }

    public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
    {
      return Range();

      IEnumerable<TEntity> Range()
      {
        foreach (TEntity entity in entities)
          yield return Update(entity);
      }
    }

    public TEntity Delete(TEntity entity)
    {
      var entry = _entityEntry(entity);
      if (entry.State == EntityState.Detached)
        _entitySet.Attach(entity);
      var deleted = _entitySet.Remove(entity);

      return deleted.Entity;
    }

    public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
    {
      return Range();

      IEnumerable<TEntity> Range()
      {
        foreach (TEntity entity in entities)
          yield return Delete(entity);
      }
    }

    public TEntity? Find(object[] keyValues, params Expression<Func<TEntity, object>>[] includes) => Include(_entitySet.Find(keyValues), includes);

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) => Include(_entitySet.FirstOrDefault(predicate), includes);

    public bool Exists(Expression<Func<TEntity, bool>> predicate) => _entitySet.Any(predicate);

    public IEnumerable<TEntity> GetAll(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      params Expression<Func<TEntity, object>>[] includes) => Includes(orderBy is not null ? orderBy(_entitySet.AsQueryable()) : null, includes);

    public IEnumerable<TEntity> GetByFilter(
      Expression<Func<TEntity, bool>> filter,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      params Expression<Func<TEntity, object>>[] includes) => Includes(orderBy is not null ? orderBy(_entitySet.Where(filter)) : _entitySet.Where(filter), includes);

    private TEntity? Include(
      TEntity? entity,
      params Expression<Func<TEntity, object>>[] includes) => entity is not null ? Includes(new[] { entity }.AsQueryable(), includes).Single() : null;

    private IEnumerable<TEntity> Includes(
      IQueryable<TEntity>? entities,
      params Expression<Func<TEntity, object>>[] includes)
    {
      entities ??= _entitySet;
      if (includes.Length == 0)
        return [.. entities];
      var querySet = entities.AsQueryable();
      foreach (var expression in includes)
        querySet = querySet.Include(expression);

      return [.. querySet];
    }
  }
}
