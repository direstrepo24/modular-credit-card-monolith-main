using Common.SharedKernel.Domain;

namespace Cards.Domain;

public class CardEntity: EntityBase<int>
{
    public string CardNumber {get; set;}
    public string OwnerName { get; set; }
    public DateTime Expirationdate { get; set; }
    public Guid UserId { get; set; }
}