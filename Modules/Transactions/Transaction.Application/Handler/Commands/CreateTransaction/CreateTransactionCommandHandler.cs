using Common.SharedKernel.Application;
using Transaction.Domain;

namespace Transaction.Application;
public class CreateTransactionCommandHandler(ITransactionService _transactionService) : ICommandHandler<CreateTransactionCommand, TransactionResponseDTO>
{
    public Task<TransactionResponseDTO> Handle(CreateTransactionCommand request, CancellationToken cancel)=> _transactionService.CreateAsync(request.Dto, cancel);
}