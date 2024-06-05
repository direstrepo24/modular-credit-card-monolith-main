using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

public class UpdateCardCommandHandler(ICardService _cardService) : ICommandHandler<UpdateCardCommand, CardResponseDTO>
{
    public Task<CardResponseDTO> Handle(UpdateCardCommand request, CancellationToken cancellationToken) => 
        _cardService.UpdateAsync(request.Id, request.Dto, cancellationToken);
}