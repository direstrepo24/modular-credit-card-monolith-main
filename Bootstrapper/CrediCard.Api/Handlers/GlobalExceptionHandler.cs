using Common.SharedKernel.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CrediCard.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not GlobalCommonException) return false;
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        var jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };
        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(buildException((GlobalCommonException)exception), jsonSettings));
        return true;
    }

    public ExceptionBase buildException(GlobalCommonException exception)
    {
        var finalException = new ExceptionBase
        {
            Key = exception.Error?.Code ?? "Unknow",
            Message = exception.Message,
            Detail = exception?.Error?.ToString() ?? ""
        };
        return finalException;
    }
}