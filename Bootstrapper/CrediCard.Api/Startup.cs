using Asp.Versioning.ApiExplorer;
using Cards.Api;
using Payment.Api;
using Transaction.Api;
namespace CrediCard.Api;

public static class Startup
{
    public static WebApplication InitApplication(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddModuleConfiguration([
            CardModule.Name,
            PaymentModule.Name,
            TransactionModule.Name
        ]);
        builder.Services.ConfigureServices(builder.Configuration);
        var app = builder.Build();
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.ConfigureServices(provider);
        return app;
    }
}