using Common.SharedKernel.Application;
using Common.SharedKernel.Domain.Enums;
using MediatR;
using Payment.Application;
using Payment.Domain;
using Payment.Integration.Events;

namespace Cards.Application;
public class CreatePaymentCommandHandler(IPaymentService _paymentService, IMediator _mediator) : ICommandHandler<CreatePaymentCommand, PaymentResponseDTO>
{
    public async Task<PaymentResponseDTO> Handle(CreatePaymentCommand request, CancellationToken cancel)
    {
         OperationState state = OperationState.None;
         
        try
        {
            state = OperationState.PaymentInitiated;
            var paymentResult = await _paymentService.CreateAsync(request.Dto, cancel);
            state = OperationState.PaymentCompleted;

            await _mediator.Publish(new CreatePaymentIntegrationEvent(
                request.Dto.UserId,
                request.Dto.CardNumber,
                request.Dto.Concept,
                request.Dto.Amount
            ));
            state = OperationState.TransactionCompleted;
             Console.WriteLine("transaccion completada");

            return paymentResult;
        }
        catch (Exception)
        {
            if (state == OperationState.PaymentCompleted)
            {
                // Compensate for the payment if necessary
                await CompensatePayment(request.Dto.UserId, cancel);
                state = OperationState.Compensated;
            }

            state = OperationState.Failed;
            throw;
        }
    }
     private async Task CompensatePayment(Guid userId, CancellationToken cancel)
    {
        // Logic to revert the payment
       // await _paymentService.RevertPaymentAsync(request.Dto, cancel);
       Console.WriteLine("Pago compensado");
    }

    public class SagaState
{
    public Guid Id { get; set; }
    public string CurrentState { get; set; }
    public OperationState Type { get; set; } // Tipo de saga, e.g., "PaymentProcessing"
    public DateTime LastUpdated { get; set; }
}

  
}