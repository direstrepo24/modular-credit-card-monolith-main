
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application;
using Transaction.Domain;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
internal class TransactionController(IMediator _mediatr): ControllerBase
{
    [HttpGet("{userId}/{cardNumber}")]
    [ProducesResponseType(typeof(IEnumerable<TransactionResponseDTO>), StatusCodes.Status200OK)]
    public Task<IEnumerable<TransactionResponseDTO>> AllByUser([FromRoute] Guid userId, string cardNumber ) => 
        _mediatr.Send(new GetAllTransactionsQuery(userId, cardNumber));
}