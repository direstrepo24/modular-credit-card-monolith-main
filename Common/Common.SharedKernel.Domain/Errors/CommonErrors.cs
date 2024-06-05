namespace Common.SharedKernel.Domain;

public static class CommonErrors
{
    public static ErrorResponse ModelInvalid(List<ErrorDetail> details) =>
        ErrorResponse.Validation("Global.ModelInvalid", "model validation error", details);

    public static ErrorResponse EntityNotFound(Type entityType, object? id = null) {
        var description = id == null ? $"There is no such an entity given id. Entity type: '{entityType.FullName}'." :
                        $"There is no such an entity. Entity type: '{entityType.FullName}', id: '{id}'.";
        return ErrorResponse.NotFound("Global.EntityNotFound", description);
    }
}