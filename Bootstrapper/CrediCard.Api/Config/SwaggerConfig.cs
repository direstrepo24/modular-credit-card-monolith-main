using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CrediCard.Api;

/// <summary>
///     Swagger
/// </summary>
public static class SwaggerConfig
{
    /// <summary> NSwag for swagger </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void SetupNSwag(this IServiceCollection services)
    {
        //services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureOptions<SwaggerOptions>();
    }

    /// <summary> NSwag for swagger </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public static void UseNSwaggerUI(this IApplicationBuilder app, IApiVersionDescriptionProvider? provider)
    {
        // NSwag Swagger
       app.UseSwagger();
       // app.UseSwaggerUI();
       app.UseSwaggerUI(options =>
        {
            foreach (var description in provider?.ApiVersionDescriptions ?? [])
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
    }
}

internal class SwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;
    public SwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        this.provider = provider;
    }
    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }
    private OpenApiInfo CreateVersionInfo(
            ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "Test API Tasks " + description.GroupName,
            Version = description.ApiVersion.ToString(),
        };
        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }
        return info;
    }
}