using System.Reflection;
using Cards.Domain;
using Cards.Infraestructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.Infraestructure.Common;

public static class ServiceExtension
{
     public static void AddInfraestructureCommonLayer(this IServiceCollection services)
    {
        // AutoMapper, this will scan and register everything that inherits AutoMapper.Profile
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // DI - IOC
        services.AddScoped<ICardRepository<CardDbContext>, CardRepository>();
        services.AddScoped<ICardService, CardService>();
    }
}
