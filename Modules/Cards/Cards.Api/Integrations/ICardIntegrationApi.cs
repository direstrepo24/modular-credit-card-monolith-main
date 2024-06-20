using Cards.Domain;
namespace Cards.Api;
public interface ICardIntegrationApi
{
    Task<IEnumerable<CardResponseDTO>> GetAllByUserAsync(Guid userId);
    Task<CardResponseDTO> CreateAsync(CreateCardRequestDTO dto);
    Task<CardResponseDTO> UpdateAsync(int id, UpdateCardRequestDTO dto);
    Task DeleteAsync(int id);
}