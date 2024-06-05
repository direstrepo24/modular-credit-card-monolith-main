using FluentValidation;
namespace Transaction.Application;
public sealed class CreateCardCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateCardCommandValidator()
    {
        RuleFor(v => v.Dto.UserId).NotNull().NotEmpty();
        RuleFor(v => v.Dto.CardNumber).NotNull().NotEmpty();
        RuleFor(v => v.Dto.Description).NotNull().NotEmpty();
    }
}