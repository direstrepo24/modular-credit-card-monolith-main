
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application;
using Payment.Domain;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
internal class PaymentController(IMediator _mediatr): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(PaymentResponseDTO), StatusCodes.Status200OK)]
    public Task<PaymentResponseDTO> Create([FromBody] CreatePaymentRequestDTO dto) => 
        _mediatr.Send(new CreatePaymentCommand(dto));

}