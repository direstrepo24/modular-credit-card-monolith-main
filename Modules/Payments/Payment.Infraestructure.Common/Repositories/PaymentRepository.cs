using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Payment.Domain;
using Payment.Infraestructure.Persistence;

namespace Payment.Infraestructure.Common;

public class PaymentRepository(IDbFactory<PaymentDbContext> dbFactory) : BaseRepository<PaymentEntity, int, PaymentDbContext>
(dbFactory), IPaymentRepository<PaymentDbContext>
{

}