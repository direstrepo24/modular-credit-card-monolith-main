namespace Common.SharedKernel.Domain;
public sealed class GlobalCommonException : Exception
{
    public GlobalCommonException(string requestName, ErrorResponse? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

     public GlobalCommonException(string requestName,  Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
    }

    public string RequestName { get; }
    public ErrorResponse? Error { get; }
}