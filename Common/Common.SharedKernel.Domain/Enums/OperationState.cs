namespace Common.SharedKernel.Domain.Enums
{
    public enum OperationState
    {
        PaymentInitiated,
        PaymentCompleted,
        TransactionInitiated,
        TransactionCompleted,
        Failed,
        Compensated
    }
}