using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;

public interface IBaseService<TQueryDTO, TEntity, TRepoRead, TContext>
{
    bool Exist(Expression<Func<TEntity, bool>> predicate);
    int Count(Expression<Func<TEntity, bool>> predicate);
    Task<TQueryDTO?> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] include);
    Task<IEnumerable<TQueryDTO>> AllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, string? orderBy = null, params string[] includes);
}

public interface IReadService<TQueryDTO, TKey, TEntity, TRepoRead, TContext> : IBaseService<TQueryDTO, TEntity, TRepoRead, TContext>
    where TEntity : class, IEntityBase<TKey>
    where TRepoRead : IReadRepository<TEntity, TContext>
    where TContext : DbContext, new()
{
    Task<TQueryDTO> FindByIdAsync(int id, CancellationToken cancellationToken = default);
}