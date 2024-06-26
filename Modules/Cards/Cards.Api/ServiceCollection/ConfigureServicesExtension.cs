﻿namespace Cards.Api;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Setup Layers
        services.SeptupLayer(configuration);
        services.SeptupIntegrationsApi();
    }
}
