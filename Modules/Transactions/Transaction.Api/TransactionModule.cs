namespace Transaction.Api;

public static class TransactionModule
{
    public static readonly string Name = "transactions";
    public static IServiceCollection AddTransactionModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServices(configuration);
        return services;
    }
}