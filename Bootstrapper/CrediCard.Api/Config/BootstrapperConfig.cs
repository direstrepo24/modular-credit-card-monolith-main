namespace CrediCard.Api;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBootstrapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });
        return serviceCollection;
    }
}