namespace CrediCard.Api;

public static class ExceptionConfig
{
    public static IServiceCollection SeptupExceptions(this IServiceCollection services)
    {
        services.AddExceptionHandler<UnknowExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        return services;
    }

}


