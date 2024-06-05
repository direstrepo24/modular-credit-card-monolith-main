using Common.SharedKernel.Domain;
using MediatR;

namespace Payment.Integration.Events;

public class  CreatePaymentIntegrationEvent(
    Guid userId, 
    string cardNumber, 
    string concept, 
    double amount
) : DomainEvent, INotification
{
    public Guid UserId { get; set; } = userId;
    public string CardNumber { get; set; } = cardNumber;
    public string Concept { get; set; } = concept;
    public double Amount { get; set; } = amount;
}