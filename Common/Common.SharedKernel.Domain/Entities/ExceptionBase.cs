namespace Common.SharedKernel.Domain;

public class ExceptionBase
{
    public string Detail { get; set; }
    public string Key { get; set; }
    public string Message { get; set; }
    public string? StackTrace { get; set; }
    public object? Data { get; set; }
}