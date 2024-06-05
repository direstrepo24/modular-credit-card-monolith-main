namespace Payment.Api;
public static class Startup
{
    public static WebApplication InitApplication(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        var path = builder.Environment.ContentRootPath;
        var env = builder.Environment.EnvironmentName;
        var configuration = builder.Configuration
            .SetBasePath(path)
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .Build();
        builder.Services.ConfigureServices(configuration);
        var app = builder.Build();
        return app;
    }
}
