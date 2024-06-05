using Common.SharedKernel.Domain;

namespace Payment.Domain;
public class CreatePaymentRequestDTO : RequestDTO
{
    public string CardNumber {get; set;}
    public string Concept { get; set; }
    public double Amount { get; set; }
    public Guid UserId { get; set; }
}