using System.Text.Json;

namespace Common.SharedKernel.Domain;

public class ErrorResponse(string code, string description, ErrorType type,  List<ErrorDetail>? details = null)
{
    public string Code { get; set; } = code;
    public string Description { get; set; } = description;
    public ErrorType Type { get; set; } = type;
    public List<ErrorDetail> Details { get; set; } = details ?? [];
    public override string ToString() => JsonSerializer.Serialize(this);
    public static ErrorResponse Failure(string code, string description, List<ErrorDetail>? details = null) =>
        new(code, description, ErrorType.Failure, details);

    public static ErrorResponse NotFound(string code, string description,  List<ErrorDetail>? details = null) =>
        new(code, description, ErrorType.NotFound, details);

    public static ErrorResponse Problem(string code, string description,  List<ErrorDetail>? details = null) =>
        new(code, description, ErrorType.Problem, details);

    public static ErrorResponse Conflict(string code, string description,  List<ErrorDetail>? details = null) =>
        new(code, description, ErrorType.Conflict, details);

    public static ErrorResponse Validation(string code, string description,  List<ErrorDetail>? details = null) =>
        new(code, description, ErrorType.Validation, details);
}

public class ErrorDetail(string key, string message)
{
    public string Key { get; set; } = key;
    public string Message { get; set; } = message;
}
