using FluentValidation;

namespace Cards.Application;

internal sealed class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
{
    internal UpdateCardCommandValidator()
    {
        RuleFor(v => v.Dto.CardNumber).NotNull().NotEmpty().MinimumLength(8).MaximumLength(15);
        RuleFor(v => v.Dto.OwnerName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}
