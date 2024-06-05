namespace Cards.Domain;

public class CardResponseDTO
{
    public int Id { get; set; }
    public string CardNumber {get; set;}
    public string OwnerName { get; set; }
    public DateTime Expirationdate { get; set; }
}
