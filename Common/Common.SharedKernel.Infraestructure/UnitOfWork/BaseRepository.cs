using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Infraestructure;
public class BaseRepository<T, TKey, TContext> : IBaseRepository<T, TContext>
       where T : class
       where TContext : DbContext, new()
{
    private TContext? _dataContext;
    private readonly DbSet<T> _dbSet;
    protected IDbFactory<TContext> DbFactory { get; private set; }
    protected TContext DbContext { get => _dataContext ??= DbFactory.Init(); }
    public BaseRepository(IDbFactory<TContext> dbFactory)
    {
        DbFactory = dbFactory;
        _dbSet = DbContext.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);
    public async Task AddRangeAsync(IEnumerable<T> EntityList, CancellationToken cancellationToken = default) =>
        await _dbSet.AddRangeAsync(EntityList, cancellationToken);
    public void Delete(T entity) => _dbSet.Remove(entity);
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    public void Update(T entity) => _dbSet.Update(entity);

    public int GetCount() => _dbSet.Count();
    public int GetCount(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).Count();

    public bool Exist(Expression<Func<T, bool>> predicate) => _dbSet.Any(predicate);

    public async Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] include)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        if (include != null)
        {
            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> Queryable() => _dbSet.AsQueryable();

    public async Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default, string? orderBy = null, params string[] includes)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        foreach (var includeExpression in includes)
        {
            query = query.Include(includeExpression);
        }
        if (predicate != null)
        {
            query = !string.IsNullOrEmpty(orderBy) ? query.OrderBy(orderBy).Where(predicate) : query.Where(predicate);
        }
        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default, string? orderBy = null, params Expression<Func<T, object>>[] include)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        foreach (var includeExpression in include)
        {
            query = query.Include(includeExpression);
        }
        if (predicate != null)
        {
            query = !string.IsNullOrEmpty(orderBy) ? query.OrderBy(orderBy).Where(predicate) : query.Where(predicate);
        }
        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }
}