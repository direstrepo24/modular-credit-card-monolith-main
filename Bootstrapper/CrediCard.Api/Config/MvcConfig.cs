using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;

namespace CrediCard.Api;

/// <summary>
///     Configure MVC options
/// </summary>
public static class MvcConfig
{
    /// <summary>
    ///     Configure controllers
    /// </summary>
    /// <param name="services"></param>
    public static void SetupControllers(this IServiceCollection services)
    {
        // API controllers
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.UseCamelCasing(true);
            options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            options.SerializerSettings.Culture = System.Globalization.CultureInfo.CurrentCulture;
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            options.SerializerSettings.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.DefaultValue;
            options.SerializerSettings.FloatParseHandling = Newtonsoft.Json.FloatParseHandling.Decimal;
            //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = true, ProcessExtensionDataNames = true, OverrideSpecifiedNames = false }
            };
            options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        });
        /* Puede ser también: services.AddHttpContextAccessor(); */
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
