using Common.SharedKernel.Application;
using Common.SharedKernel.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CrediCard.Api;

public class UnknowExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is GlobalCommonException) return false;
        var jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };
        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionBase
        {
            Key = "Unknow",
            Message = exception.Message,
            Detail = "Unhandled exception occurred",
        }, jsonSettings));
        return true;
    }
}
