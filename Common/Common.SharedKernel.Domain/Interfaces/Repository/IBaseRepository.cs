using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;
public interface IBase<T>
       where T : class
{
    Task AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> EntityList, CancellationToken cancellationToken = default);
    void Update(T Entity);
    void Delete(T entity);
}

public interface IBaseRepository<T, TContext> : IBase<T>, IReadRepository<T, TContext>
   where T : class
   where TContext : DbContext, new()
{ }