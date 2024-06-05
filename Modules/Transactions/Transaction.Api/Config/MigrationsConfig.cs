
using Microsoft.EntityFrameworkCore;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Api;

public static class MigrationsConfig
{
    public static void ApplyMigrationsTransactionModule(this IApplicationBuilder app, IServiceScope scope)
    {
       ApplyMigration<TransactionDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }
}
