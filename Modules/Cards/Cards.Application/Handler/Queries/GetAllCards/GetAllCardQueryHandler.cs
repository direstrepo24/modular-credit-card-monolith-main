using Cards.Domain;
using MediatR;

namespace Cards.Application;

public class GetAllCardQueryHandler(ICardService cardService) : IRequestHandler<GetAllCardsQuery, IEnumerable<CardResponseDTO>>
{
    private readonly ICardService _cardService = cardService;
    Task<IEnumerable<CardResponseDTO>> IRequestHandler<GetAllCardsQuery, IEnumerable<CardResponseDTO>>.Handle(
            GetAllCardsQuery request, CancellationToken cancel)
        => _cardService.AllByUserAsync(request.UserId,cancel);
}
