using Cards.Application;
using Cards.Domain;
using MediatR;

namespace Cards.Api;

internal class CardIntegrationApi(IMediator _mediator) : ICardIntegrationApi
{
    public Task<IEnumerable<CardResponseDTO>> GetAllByUserAsync(Guid userId) =>
        _mediator.Send(new GetAllCardsQuery(userId));

    public Task<CardResponseDTO> CreateAsync(CreateCardRequestDTO dto) =>
        _mediator.Send(new CreateCardCommand(dto));

    public Task<CardResponseDTO> UpdateAsync(int id, UpdateCardRequestDTO dto) =>
        _mediator.Send(new UpdateCardCommand(id, dto));

    public Task DeleteAsync(int id) => _mediator.Send(new DeleteCardCommand(id));
}
