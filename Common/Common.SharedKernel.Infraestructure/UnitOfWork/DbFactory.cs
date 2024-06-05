using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Infraestructure;

public class DbFactory<TContext>(Func<TContext> dbContextFactory) : IDisposable, IDbFactory<TContext>
        where TContext : DbContext, new()
{
    private bool _disposed;
    private TContext? _dbContext;
    private readonly Func<TContext> _instanceFunc = dbContextFactory;

    public void Dispose()
    {
        if (!_disposed && _dbContext != null)
        {
            _disposed = true; _dbContext.Dispose(); GC.SuppressFinalize(this);
        }
    }
    public TContext Init() => _dbContext ??= _instanceFunc.Invoke();
}
