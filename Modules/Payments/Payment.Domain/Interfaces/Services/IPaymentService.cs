
namespace Payment.Domain;
public interface IPaymentService
{
    Task<PaymentResponseDTO> CreateAsync(CreatePaymentRequestDTO request, CancellationToken cancellation);
}