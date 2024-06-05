using Cards.Domain;
using Common.SharedKernel.Application;
using Common.SharedKernel.Domain;

namespace Cards.Application;

public class DeleteCardCommandHandler(ICardService _cardService) : ICommandHandler<DeleteCardCommand, NoResult>
{
    public Task<NoResult> Handle(DeleteCardCommand request, CancellationToken cancel) =>
        _cardService.DeleteAsync(request.id, cancel);
}