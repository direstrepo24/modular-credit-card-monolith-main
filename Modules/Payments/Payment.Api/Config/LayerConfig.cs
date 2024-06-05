using Payment.Application;
using Payment.Infraestructure.Common;
using Payment.Infraestructure.Persistence;

namespace Payment.Api;
/// <summary>
/// Configure layers
/// </summary>
public static class LayerConfig
{
    /// <summary> Layer </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void SeptupLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraestructureCommonLayer();
        services.AddApplicationLayer();
        services.AddInfraestructurePersistenceLayer(configuration);
    }
}
