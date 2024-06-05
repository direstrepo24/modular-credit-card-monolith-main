using Common.SharedKernel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.SharedKernel.Application;

public sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);
            if (exception is GlobalCommonException) throw;
            throw new GlobalCommonException(typeof(TRequest).Name,  exception);
        }
    }
}
 