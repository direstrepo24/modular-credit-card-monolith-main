using Payment.Api;
using Cards.Api;
using Transaction.Api;

namespace CrediCard.Api;
public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Modules
        services
        .AddCardModule(configuration)
        .AddPaymentModule(configuration)
        .AddTransactionModule(configuration)
        .AddBootstrapper();
        //Exceptions
        services.SeptupExceptions();
        // Add services to the container.
        services.SetupControllers();
        //Api versioning
        services.SetupApiVersioning();
        // NSwag Swagger
        services.SetupNSwag();
        // Cors
        services.SeptupCors();
    }
}