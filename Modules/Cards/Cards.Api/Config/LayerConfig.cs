using Cards.Infraestructure.Common;
using Cards.Infraestructure.Persistence;
using Cards.Application;

namespace Cards.Api;
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
