namespace Transaction.Domain;
public enum CreditCardTransactionType
{
    Purchase,          // Compra
    CashAdvance,       // Adelanto en efectivo
    Payment,           // Pago
    Refund,            // Reembolso
    Chargeback,        // Contracargo
    Fee,               // Comisión
    InterestCharge,    // Cargo de intereses
    BalanceTransfer,   // Transferencia de saldo
    RewardRedemption   // Redención de recompensas
}