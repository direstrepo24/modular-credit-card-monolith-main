using Cards.Domain;
using Common.SharedKernel.Application;
using MediatR;

namespace Cards.Application;
internal class CreateCardCommandHandler(ICardService _cardService, IMediator _mediator) : ICommandHandler<CreateCardCommand, CardResponseDTO>
{
    public async Task<CardResponseDTO> Handle(CreateCardCommand request, CancellationToken cancel)
    {
        var result =   await _cardService.CreateAsync(request.Dto, cancel);
        await _mediator.Publish(new CreateCardEvent{
            CardNumber = request.Dto.CardNumber,
            Expirationdate = request.Dto.Expirationdate,
            OwnerName= request.Dto.OwnerName,
            UserId = request.Dto.UserId
        });
        return result;
    }
}