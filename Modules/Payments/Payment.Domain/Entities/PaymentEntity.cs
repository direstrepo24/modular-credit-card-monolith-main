using Common.SharedKernel.Domain;

namespace Payment.Domain;

public class PaymentEntity: EntityBase<int>
{
    public string CardNumber {get; set;}
    public string Concept { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
}