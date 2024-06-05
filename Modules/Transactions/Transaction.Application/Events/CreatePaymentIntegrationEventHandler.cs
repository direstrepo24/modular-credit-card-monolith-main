using Common.SharedKernel.Application;
using MediatR;
using Payment.Integration.Events;
using Transaction.Domain;

namespace Transaction.Application;

public class CreatePaymentIntegrationEventHandler(IMediator sender) : IDomainEventHandler<CreatePaymentIntegrationEvent>
{
    public async Task Handle(CreatePaymentIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var dto = new CreateTransactionRequestDTO
        {
            Amount= notification.Amount,
            CardNumber = notification.CardNumber,
            Date = notification.OccurredOnUtc,
            Description = notification.Concept,
            Type = CreditCardTransactionType.Payment,
            UserId = notification.UserId
        };
        await sender.Send(new CreateTransactionCommand(dto), cancellationToken);
    }
}
