using Clob.Application.Features.Orders.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Clob.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderCommand command,
        [FromServices] CreateOrderCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
