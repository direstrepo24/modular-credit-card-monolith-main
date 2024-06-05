using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.Infraestructure.Persistence;

public static class ServiceExtension
{
    public static void AddInfraestructurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var db = configuration.GetSection("Card:Database").Value;
        services.AddDbContext<CardDbContext>(options => {
                options.UseNpgsql(db,
                b => b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Card));
                options.EnableSensitiveDataLogging();
            });
        //crear instancia de CardDbContext de manera flexible y diferida
        services.AddScoped<Func<CardDbContext?>>((provider) => () => provider.GetService<CardDbContext>());

        //UnitOfWork and Factory
        services.AddScoped<IDbFactory<CardDbContext>, DbFactory<CardDbContext>>();
        services.AddScoped<IUnitOfWork<CardDbContext>, UnitOfWork<CardDbContext>>();
    }
}
