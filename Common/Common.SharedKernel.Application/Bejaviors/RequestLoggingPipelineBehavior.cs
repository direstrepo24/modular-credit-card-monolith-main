using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.SharedKernel.Application;
public sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string moduleName = GetModuleName(typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        Activity.Current?.SetTag("request.module", moduleName);
        Activity.Current?.SetTag("request.name", requestName);

        logger.LogInformation($"Processing handling  {moduleName}:{requestName}", requestName, request);
        var response = await next();
        logger.LogInformation($"Completed handling {moduleName}:{requestName}");
        return response;
    }

    private static string GetModuleName(string requestName) => requestName.Split('.')[1];
}