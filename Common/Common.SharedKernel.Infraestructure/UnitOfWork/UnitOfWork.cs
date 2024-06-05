using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.SharedKernel.Infraestructure;

public class UnitOfWork<TContext>(IDbFactory<TContext> dbFactory) : IUnitOfWork<TContext>
       where TContext : DbContext, new()
{
    private TContext? _dbContext;
    private IDbContextTransaction? _objTran;
    private readonly IDbFactory<TContext> _dbFactory = dbFactory;

    public TContext DbContext { get { return _dbContext ??= _dbFactory.Init(); } }

    #region "CreateTransaction"
    public void CreateTransaction() => _objTran = DbContext.Database.BeginTransaction();
    public async Task CreateTransactionAsync() => _objTran = await DbContext.Database.BeginTransactionAsync();
    public async Task CreateTransactionAsync(CancellationToken cancellationToken = default) =>
        _objTran = await DbContext.Database.BeginTransactionAsync(cancellationToken);
    #endregion "CreateTransaction"

    #region "Commit"
    public void Commit() => _objTran?.Commit();
    public async Task CommitAsync(CancellationToken cancellationToken = default) {
        if (_objTran is null) return;
        await _objTran.CommitAsync(cancellationToken);
    }
    #endregion "Commit"


    #region "SaveChanges"
    public void SaveChanges() => DbContext.SaveChanges();
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => 
        await DbContext.SaveChangesAsync(cancellationToken);
    public async Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)=> 
        await DbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    #endregion

    #region "Rollback"
    public void Rollback() { 
        _objTran?.Rollback(); 
        _objTran?.Dispose(); 
    }
    public async Task RollbackAsync() {
        if (_objTran is null) return;
        await _objTran.RollbackAsync(); 
        await _objTran.DisposeAsync(); 
    }
    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_objTran is null) return;
        await _objTran.RollbackAsync(cancellationToken); await _objTran.DisposeAsync();
    }
    #endregion "Rollback"
}
