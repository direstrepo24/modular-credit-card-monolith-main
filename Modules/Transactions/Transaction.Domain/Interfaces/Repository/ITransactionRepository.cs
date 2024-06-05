using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
namespace Transaction.Domain;
public interface ITransactionRepository<TContext> : IBaseRepository<TransactionEntity, TContext>
    where TContext: DbContext, new()
{

}