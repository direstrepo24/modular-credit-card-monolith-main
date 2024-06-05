using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
namespace Payment.Domain;
public interface IPaymentRepository<TContext> : IBaseRepository<PaymentEntity, TContext>
    where TContext: DbContext, new()
{

}