using Common.SharedKernel.Domain;

namespace Transaction.Domain;
public class CreateTransactionRequestDTO : RequestDTO
{
    public string CardNumber {get; set;}
    public CreditCardTransactionType Type { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
}