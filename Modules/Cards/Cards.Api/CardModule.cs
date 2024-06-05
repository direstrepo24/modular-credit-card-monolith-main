namespace Cards.Api;

public static class CardModule
{
    public static readonly string Name = "cards";
    public static IServiceCollection AddCardModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServices(configuration);
        return services;
    }
}
