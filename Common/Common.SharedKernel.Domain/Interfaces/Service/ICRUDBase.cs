using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;
public interface ICRUDBase<TQueryDTO, TRequestDTO, TEntity, TRepoAll, TContext>
{
    Task<TQueryDTO> InsertAsync(TRequestDTO objDTO, CancellationToken cancellationToken = default);
    Task<TQueryDTO> DeleteAsync(Expression<Func<TEntity, bool>> keyPredicate, TRequestDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    Task<TQueryDTO> UpdateAsync(Expression<Func<TEntity, bool>> keyPredicate, TRequestDTO objDTO, CancellationToken cancellationToken = default);

}
public interface ICRUDService<TQueryDTO, TRequestDTO, TKey, TEntity, TRepoAll, TContext> : ICRUDBase<TQueryDTO, TRequestDTO, TEntity, TRepoAll, TContext>, IReadService<TQueryDTO, TKey, TEntity, TRepoAll, TContext>
    where TEntity : class, IEntityBase<TKey>
    where TRepoAll : IBaseRepository<TEntity, TContext>
    where TContext : DbContext, new()
{
    Task<TQueryDTO> UpdateAsync(TRequestDTO objDTO, CancellationToken cancellationToken = default);
    Task<TQueryDTO> DeleteAsync(TRequestDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
}