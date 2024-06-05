namespace Payment.Api;

public static class PaymentModule
{
    public static readonly string Name = "payments";
    public static IServiceCollection AddPaymentModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServices(configuration);
        return services;
    }
}