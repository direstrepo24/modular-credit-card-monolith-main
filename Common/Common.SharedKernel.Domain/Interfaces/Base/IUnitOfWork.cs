using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;
public interface IUnitOfWork<TContext>
       where TContext : DbContext, new()
{
    void CreateTransaction();
    Task CreateTransactionAsync();
    Task CreateTransactionAsync(CancellationToken cancellationToken = default);
    void Rollback();
    Task RollbackAsync();
    Task RollbackAsync(CancellationToken cancellationToken = default);
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken = default);

    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}