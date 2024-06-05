using AutoMapper;
using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;
using Payment.Domain;
using Payment.Infraestructure.Persistence;

namespace Payment.Infraestructure.Common;

public class PaymentService : CRUDService<PaymentResponseDTO, RequestDTO, int, PaymentEntity, IPaymentRepository<PaymentDbContext>, PaymentDbContext>, IPaymentService
{
    public PaymentService(IMapper mapper, IPaymentRepository<PaymentDbContext> repository, IUnitOfWork<PaymentDbContext> unitOfWork): base(mapper, repository, unitOfWork){

    }

    public Task<PaymentResponseDTO> CreateAsync(CreatePaymentRequestDTO request, CancellationToken cancellation) =>
        InsertAsync(request);
}