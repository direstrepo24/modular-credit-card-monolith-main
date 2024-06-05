using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;

public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
{
    TContext Init();
}
