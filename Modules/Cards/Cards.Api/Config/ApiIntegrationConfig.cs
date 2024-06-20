namespace Cards.Api;
/// <summary>
/// Configure Integrations API
/// </summary>
public static class ServiceConfig
{
    /// <summary> Api </summary>
    /// <param name="services"></param>
    public static void SeptupIntegrationsApi(this IServiceCollection services)
    {
        services.AddScoped<ICardIntegrationApi, CardIntegrationApi>();
    }
}