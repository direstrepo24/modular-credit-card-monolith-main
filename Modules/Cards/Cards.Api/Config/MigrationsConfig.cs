using Cards.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cards.Api;

public static class MigrationsConfig
{
    public static void ApplyMigrationsCardModule(this IApplicationBuilder app, IServiceScope scope)
    {
        ApplyMigration<CardDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }
}
