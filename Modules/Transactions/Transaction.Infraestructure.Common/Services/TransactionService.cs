using AutoMapper;
using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Transaction.Domain;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Infraestructure.Common;

public class TransactionService : CRUDService<TransactionResponseDTO, RequestDTO, int, TransactionEntity, ITransactionRepository<TransactionDbContext>, TransactionDbContext>, ITransactionService
{
    public TransactionService(IMapper mapper, ITransactionRepository<TransactionDbContext> repository, IUnitOfWork<TransactionDbContext> unitOfWork): base(mapper, repository, unitOfWork){

    }

    public Task<IEnumerable<TransactionResponseDTO>> AllAsync(Guid userId, string cardNumber, CancellationToken cancellation) => AllAsync(a => a.CardNumber == cardNumber && a.UserId == userId, cancellation);

    public Task<TransactionResponseDTO> CreateAsync(CreateTransactionRequestDTO request, CancellationToken cancellation) =>        
        InsertAsync(request, cancellation);
}