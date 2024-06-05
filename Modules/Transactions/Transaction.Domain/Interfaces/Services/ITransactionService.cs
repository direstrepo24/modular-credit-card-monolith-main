namespace Transaction.Domain;
public interface ITransactionService
{
    Task<TransactionResponseDTO> CreateAsync(CreateTransactionRequestDTO request, CancellationToken cancellation);
    Task<IEnumerable<TransactionResponseDTO>> AllAsync(Guid userId, string cardNumber , CancellationToken cancellation);

}