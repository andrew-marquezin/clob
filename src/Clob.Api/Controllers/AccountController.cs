using Clob.Application.Abstractions.Messaging;
using Clob.Application.Features.Accounts;
using Clob.Application.Features.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Clob.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("{accountId:guid}/balance")]
    public async Task<IActionResult> GetBalance(
        [FromRoute] Guid accountId,
        [FromServices] IQueryHandler<GetBalanceQuery, GetBalanceOutput> handler,
        CancellationToken cancellationToken)
    {
        var query = new GetBalanceQuery(accountId);
        var result = await handler.Handle(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}
