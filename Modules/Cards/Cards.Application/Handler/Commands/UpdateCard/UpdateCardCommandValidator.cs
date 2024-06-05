using FluentValidation;

namespace Cards.Application;

public sealed class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
{
    public UpdateCardCommandValidator()
    {
        RuleFor(v => v.Dto.CardNumber).NotNull().NotEmpty().MinimumLength(8).MaximumLength(15);
        RuleFor(v => v.Dto.OwnerName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}
