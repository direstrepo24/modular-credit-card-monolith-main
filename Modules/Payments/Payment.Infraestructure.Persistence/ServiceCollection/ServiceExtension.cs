using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payment.Infraestructure.Persistence;
public static class ServiceExtension
{
    public static void AddInfraestructurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var db = configuration.GetSection("Payment:Database").Value;
        services.AddDbContext<PaymentDbContext>(options => {
                options.UseNpgsql(db,
                b => b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Payment));
                options.EnableSensitiveDataLogging();
            });
        //crear instancia de PaymentDbContext de manera flexible y diferida
        services.AddScoped<Func<PaymentDbContext?>>((provider) => () => provider.GetService<PaymentDbContext>());

        //UnitOfWork and Factory
        services.AddScoped<IDbFactory<PaymentDbContext>, DbFactory<PaymentDbContext>>();
        services.AddScoped<IUnitOfWork<PaymentDbContext>, UnitOfWork<PaymentDbContext>>();
    }
}
