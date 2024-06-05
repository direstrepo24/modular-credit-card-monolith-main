

using Asp.Versioning;
using Asp.Versioning.Conventions;

namespace CrediCard.Api;

/// <summary>
/// Api Versioning
/// </summary>
public static class ApiVersioningConfig
{
    /// <summary> NSwag for swagger </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void SetupApiVersioning(this IServiceCollection services)
    {
        //https://medium.com/@dipendupaul/documenting-a-versioned-net-web-api-using-swagger-eec0fe7aa010
        services.AddApiVersioning(
             options =>
             {
                 options.DefaultApiVersion = new ApiVersion(1.0);
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 // reporting api versions will return the headers
                 options.ReportApiVersions = true;
             })
         .AddMvc(
             options =>
             {
                 // automatically applies an api version based on the name of
                 // the defining controller's namespace
                 options.Conventions.Add(new VersionByNamespaceConvention());
             })
         .AddApiExplorer(setup =>
             {
                 setup.GroupNameFormat = "'v'VVV";
                 setup.SubstituteApiVersionInUrl = true;
             });
    }
}