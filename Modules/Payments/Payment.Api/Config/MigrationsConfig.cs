
using Microsoft.EntityFrameworkCore;
using Payment.Infraestructure.Persistence;

namespace Payment.Api;

public static class MigrationsConfig
{
    public static void ApplyMigrationsPaymentModule(this IApplicationBuilder app, IServiceScope scope)
    {
       ApplyMigration<PaymentDbContext>(scope);
    }

   private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }
}
