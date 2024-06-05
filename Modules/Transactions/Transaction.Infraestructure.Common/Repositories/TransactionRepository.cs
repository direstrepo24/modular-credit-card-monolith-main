using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Transaction.Domain;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Infraestructure.Common;

public class TransactionRepository(IDbFactory<TransactionDbContext> dbFactory): BaseRepository<TransactionEntity, int, TransactionDbContext>
(dbFactory), ITransactionRepository<TransactionDbContext>
{

}
