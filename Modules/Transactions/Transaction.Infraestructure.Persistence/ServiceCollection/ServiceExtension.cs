using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Transaction.Infraestructure.Persistence;

public static class ServiceExtension
{
    public static void AddInfraestructurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var db = configuration.GetSection("Transaction:Database").Value;
        services.AddDbContext<TransactionDbContext>(options => {
                options.UseNpgsql(db,
                b => b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Transaction));
                options.EnableSensitiveDataLogging();
            });
        //crear instancia de TransactionDbContext de manera flexible y diferida
        services.AddScoped<Func<TransactionDbContext?>>((provider) => () => provider.GetService<TransactionDbContext>());

        //UnitOfWork and Factory
        services.AddScoped<IDbFactory<TransactionDbContext>, DbFactory<TransactionDbContext>>();
        services.AddScoped<IUnitOfWork<TransactionDbContext>, UnitOfWork<TransactionDbContext>>();
    }
}
