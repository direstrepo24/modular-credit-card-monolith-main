using Common.SharedKernel.Application;
using MediatR;
using Payment.Application;
using Payment.Domain;
using Payment.Integration.Events;

namespace Cards.Application;
public class CreatePaymentCommandHandler(IPaymentService _paymentService, IMediator _mediator) : ICommandHandler<CreatePaymentCommand, PaymentResponseDTO>
{
    public async Task<PaymentResponseDTO> Handle(CreatePaymentCommand request, CancellationToken cancel)
    {
        var result =   await _paymentService.CreateAsync(request.Dto, cancel);
        //guardo estado
        await _mediator.Publish(new CreatePaymentIntegrationEvent(
            request.Dto.UserId,
            request.Dto.CardNumber,
            request.Dto.Concept,
            request.Dto.Amount
        ));
//guardto

        return result;
    }
}