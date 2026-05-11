using Clob.Domain.Abstractions;
using Clob.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clob.Infrastructure.DataAccess.Repositories;

public class AccountRepository(ClobDbContext context) : IAccountRepository
{
    public Task<Account?> GetAccountById(Guid id) => context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
}
