using Clob.Domain.Entities;

namespace Clob.Domain.Abstractions;

public interface IAccountRepository
{
    Task<Account?> GetAccountById(Guid id);
}
