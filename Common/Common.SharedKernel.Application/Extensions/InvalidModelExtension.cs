using Common.SharedKernel.Domain;
using FluentValidation.Results;

namespace Common.SharedKernel.Application;

public static class InvalidModelExtension
{
    public static ErrorResponse InvalidModel(this ValidationResult context)
    {
        return context is null ?
            throw new ArgumentNullException(nameof(context)) :
            CommonErrors.ModelInvalid(GetErrors(context.Errors));
    }

    public static ErrorResponse InvalidModel(this List<ValidationFailure> errors) =>
            CommonErrors.ModelInvalid(GetErrors(errors));

    public static List<ErrorDetail> GetErrors(List<ValidationFailure> errors) =>
        errors.Select(x =>
                new ErrorDetail(
                    key: x.ErrorCode,
                    message: $"{x.PropertyName} : {x.ErrorMessage}"))
            .ToList();
}