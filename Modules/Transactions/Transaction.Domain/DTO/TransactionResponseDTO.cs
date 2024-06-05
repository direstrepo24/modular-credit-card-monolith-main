namespace Transaction.Domain;

public class TransactionResponseDTO
{
    public string Type { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
}
