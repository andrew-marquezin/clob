using Clob.Application.Abstractions.Messaging;
using Clob.Domain.Abstractions;
using Clob.SharedKernel;

namespace Clob.Application.Features.Accounts.Queries;

public sealed record GetBalanceQuery(Guid Id) : IQuery<GetBalanceOutput>;

public sealed class GetBalanceQueryHandler(IAccountRepository repository)
    : IQueryHandler<GetBalanceQuery, GetBalanceOutput>
{
    public async Task<Result<GetBalanceOutput>> Handle(GetBalanceQuery query, CancellationToken cancellationToken)
    {
        var account = await repository.GetAccountById(query.Id);
        return account is null
            ? Result.Failure<GetBalanceOutput>(AccountErrors.NotFound(query.Id))
            : Result.Success(new GetBalanceOutput(account.BalanceBrl, account.BalanceBtc));
    }
}

public static class AccountErrors
{
    public static Error NotFound(Guid id) => new(
        "Account.NotFound",
        $"The Account with id = {id} was not found.");
}
