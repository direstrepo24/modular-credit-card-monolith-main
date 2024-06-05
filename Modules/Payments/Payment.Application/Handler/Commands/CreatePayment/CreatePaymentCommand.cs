using Common.SharedKernel.Application;
using Payment.Domain;

namespace Payment.Application;

public sealed record CreatePaymentCommand(CreatePaymentRequestDTO Dto): ICommand<PaymentResponseDTO> { }
