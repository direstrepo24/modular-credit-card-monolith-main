using AutoMapper;
using Cards.Domain;
using Cards.Infraestructure.Persistence;
using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;

namespace Cards.Infraestructure.Common;

public class CardService : CRUDService<CardResponseDTO, RequestDTO, int, CardEntity, ICardRepository<CardDbContext>, CardDbContext>, ICardService
{
    public CardService(IMapper mapper, ICardRepository<CardDbContext> repository, IUnitOfWork<CardDbContext> unitOfWork): base(mapper, repository, unitOfWork){

    }
    public Task<IEnumerable<CardResponseDTO>> AllByUserAsync(Guid userId, CancellationToken cancellation) => base.AllAsync(a=>a.UserId==userId,cancellation);

    public Task<CardResponseDTO> CreateAsync(CreateCardRequestDTO request, CancellationToken cancellation) =>        InsertAsync(request, cancellation);

    public async  Task<NoResult> DeleteAsync(int id, CancellationToken cancellation) {
        await base.DeleteAsync(a => a.Id == id, null, false, cancellation);
        return NoResult.Instance;
    }

    public Task<CardResponseDTO> UpdateAsync(int id, UpdateCardRequestDTO request, CancellationToken cancellation) => base.UpdateAsync(a => a.Id == id, request, cancellation);
}