using Asp.Versioning;
using Cards.Application;
using Cards.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cards.Api;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
internal class CardController(IMediator _mediatr): ControllerBase
{
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<CardResponseDTO>), StatusCodes.Status200OK)]
    public Task<IEnumerable<CardResponseDTO>> GetAllByUser([FromRoute] Guid userId) => 
        _mediatr.Send(new GetAllCardsQuery(userId));

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<CardResponseDTO>), StatusCodes.Status200OK)]
    public Task<CardResponseDTO> Create([FromBody] CreateCardRequestDTO dto) => 
        _mediatr.Send(new CreateCardCommand(dto));

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CardResponseDTO), StatusCodes.Status200OK)]
    public Task<CardResponseDTO> Update([FromRoute] int id, [FromBody] UpdateCardRequestDTO dto) => 
        _mediatr.Send(new UpdateCardCommand(id, dto));

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
    public async Task<NoContentResult> Delete([FromRoute] int id) {
        await _mediatr.Send(new DeleteCardCommand(id));
        return NoContent();
    }
}