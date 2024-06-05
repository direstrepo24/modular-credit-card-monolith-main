using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Payment.Domain;
using Payment.Infraestructure.Persistence;

namespace Payment.Infraestructure.Common;

public static class ServiceExtension
{
     public static void AddInfraestructureCommonLayer(this IServiceCollection services)
    {
        // AutoMapper, this will scan and register everything that inherits AutoMapper.Profile
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // DI - IOC
        services.AddScoped<IPaymentRepository<PaymentDbContext>, PaymentRepository>();
        services.AddScoped<IPaymentService, PaymentService>();
    }
}
