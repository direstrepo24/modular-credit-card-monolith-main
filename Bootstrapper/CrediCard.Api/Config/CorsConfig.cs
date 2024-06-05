namespace CrediCard.Api;


public static class CorsConfig
{
    public readonly static string MyPolicy = "_myPolicy";
    public static IServiceCollection SeptupCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                MyPolicy,
                x =>
                {
                    x.AllowAnyHeader()
                    .AllowAnyMethod()
                    //.WithOrigins("http://localhost:4200/")
                    .SetIsOriginAllowed(isOriginAllowed: _ => true)
                    .AllowCredentials();
                });
        });
        services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);
        return services;
    }
}