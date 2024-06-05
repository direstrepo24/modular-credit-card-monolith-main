using Common.SharedKernel.Domain;

namespace Cards.Domain;

public class CreateCardRequestDTO : RequestDTO
{
    public Guid UserId { get; set; }
    public string CardNumber {get; set;}
    public string OwnerName { get; set; }
    public DateTime Expirationdate { get; set; }
}

public class UpdateCardRequestDTO : RequestDTO
{
    public string CardNumber {get; set;}
    public string OwnerName { get; set; }
    public DateTime Expirationdate { get; set; }
}