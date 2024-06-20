using Asp.Versioning;
using Cards.Api;
using Cards.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application;

namespace CrediCard.Api;

[ApiVersion("2.0")]
[Route("api/bff/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class CrediCardDetailt(IMediator _mediator, ICardIntegrationApi _cardIntegrationApi): ControllerBase
{
    [HttpGet("{userId}/{cardNumber}")]
    [ProducesResponseType(typeof(IEnumerable<DetailTransactionDTO>), StatusCodes.Status200OK)]
    public async  Task<IEnumerable<DetailTransactionDTO>> AllByUser([FromRoute] Guid userId, string cardNumber ) {
        var result = await _mediator.Send(new GetAllTransactionsQuery(userId, cardNumber));
        var mapper = result.Select(transaccion => new DetailTransactionDTO
        {
            Amount = transaccion.Amount,
            Date = transaccion.Date,
            Description = transaccion.Description,
            UserName = "Text tranformado a visualizar"
        });
        return mapper;
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<CardResponseDTO>), StatusCodes.Status200OK)]
    public Task<IEnumerable<CardResponseDTO>> GetAllCardsByUser([FromRoute] Guid userId) => 
        _cardIntegrationApi.GetAllByUserAsync(userId);
}


public class DetailTransactionDTO {
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string UserName { get; set; }
}
