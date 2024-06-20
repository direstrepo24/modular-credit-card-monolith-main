using MediatR;

namespace Cards.Application;

internal class CreateCardEvent: INotification
{
    public Guid UserId { get; set; }
    public string CardNumber {get; set;}
    public string OwnerName { get; set; }
    public DateTime Expirationdate { get; set; }
}
