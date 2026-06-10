using Clob.Domain.Abstractions;
using Clob.Domain.Entities;

namespace Clob.Infrastructure.DataAccess.Repositories;

public class OrderRepository(ClobDbContext context) : IOrderRepository
{
    public async Task AddAsync(Order order, CancellationToken cancellationToken) =>
        await context.Orders.AddAsync(order, cancellationToken);
}
