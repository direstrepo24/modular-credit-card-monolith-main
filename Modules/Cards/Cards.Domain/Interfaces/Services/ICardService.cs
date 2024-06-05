using Common.SharedKernel.Domain;
namespace Cards.Domain;
public interface ICardService
{
    Task<IEnumerable<CardResponseDTO>> AllByUserAsync(Guid userId, CancellationToken cancellation);
    Task<CardResponseDTO> CreateAsync(CreateCardRequestDTO request, CancellationToken cancellation);
    Task<CardResponseDTO> UpdateAsync(int id, UpdateCardRequestDTO request, CancellationToken cancellation);
    Task<NoResult> DeleteAsync(int id, CancellationToken cancellation);
}