using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Domain;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Infraestructure.Common;

public static class ServiceExtension
{
     public static void AddInfraestructureCommonLayer(this IServiceCollection services)
    {
        // AutoMapper, this will scan and register everything that inherits AutoMapper.Profile
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // DI - IOC
        services.AddScoped<ITransactionRepository<TransactionDbContext>, TransactionRepository>();
        services.AddScoped<ITransactionService, TransactionService>();
    }
}
