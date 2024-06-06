namespace Common.SharedKernel.Domain.Enums
{
    public enum OperationState
    {
        None,
        PaymentInitiated,
        PaymentCompleted,
        TransactionInitiated,
        TransactionCompleted,
        Failed,
        Compensated
    }
}