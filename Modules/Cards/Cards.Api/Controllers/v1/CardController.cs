using Asp.Versioning;
using Cards.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Cards.Api;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
internal class CardController(ICardIntegrationApi _cardIntegrationApi): ControllerBase
{
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<CardResponseDTO>), StatusCodes.Status200OK)]
    public Task<IEnumerable<CardResponseDTO>> GetAllByUser([FromRoute] Guid userId) => 
        _cardIntegrationApi.GetAllByUserAsync(userId);

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<CardResponseDTO>), StatusCodes.Status200OK)]
    public Task<CardResponseDTO> Create([FromBody] CreateCardRequestDTO dto) => 
        _cardIntegrationApi.CreateAsync(dto);

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CardResponseDTO), StatusCodes.Status200OK)]
    public Task<CardResponseDTO> Update([FromRoute] int id, [FromBody] UpdateCardRequestDTO dto) => 
        _cardIntegrationApi.UpdateAsync(id, dto);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
    public async Task<NoContentResult> Delete([FromRoute] int id) {
        await _cardIntegrationApi.DeleteAsync(id);
        return NoContent();
    }
}