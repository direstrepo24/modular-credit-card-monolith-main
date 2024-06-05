using Common.SharedKernel.Application;
using Transaction.Domain;

namespace Transaction.Application;

public sealed record CreateTransactionCommand(CreateTransactionRequestDTO Dto): ICommand<TransactionResponseDTO> { }
