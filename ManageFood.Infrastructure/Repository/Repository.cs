using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ManageFood.Contracts.Repository;

namespace ManageFood.Infrastructure.Repository
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

    public TEntity? Find(params object[] primaryKeys) => _entitySet.Find(primaryKeys);

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate) => _entitySet.FirstOrDefault(predicate);

    public bool Exists(Expression<Func<TEntity, bool>> predicate) => _entitySet.Any(predicate);

    public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, bool>>[] includes) => Includes(null, includes);

    public IEnumerable<TEntity> GetByFilter(
      Expression<Func<TEntity, bool>> filter,
      params Expression<Func<TEntity, bool>>[] includes) => Includes(_entitySet.Where(filter), includes);

    public IEnumerable<TEntity> GetByOrder(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
      params Expression<Func<TEntity, bool>>[] includes) => Includes(orderBy(_entitySet.AsQueryable()), includes);

    private IEnumerable<TEntity> Includes(
      IQueryable<TEntity>? entities,
      params Expression<Func<TEntity, bool>>[] includes)
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
