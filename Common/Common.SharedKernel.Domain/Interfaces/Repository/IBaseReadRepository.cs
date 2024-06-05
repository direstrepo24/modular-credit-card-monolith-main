using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;
public interface IBaseReadRepository<T>
           where T : class
{
    int GetCount();
    bool Exist(Expression<Func<T, bool>> predicate);
    int GetCount(Expression<Func<T, bool>> predicate);
    IQueryable<T> Queryable();
    Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] include);
    Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default, string? orderBy = null, params string[] includes);
}

public interface IReadRepository<T, TContext> : IBaseReadRepository<T>
    where T : class
    where TContext : DbContext, new()
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}