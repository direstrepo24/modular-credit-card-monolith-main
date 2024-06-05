using FluentValidation;
using Payment.Application;
namespace Cards.Application;
public sealed class CreateCardCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreateCardCommandValidator()
    {
        RuleFor(v => v.Dto.UserId).NotNull().NotEmpty();
        RuleFor(v => v.Dto.CardNumber).NotNull().NotEmpty();
        RuleFor(v => v.Dto.Concept).NotNull().NotEmpty();
    }
}