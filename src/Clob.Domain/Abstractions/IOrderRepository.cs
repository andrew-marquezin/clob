using Clob.Domain.Entities;

namespace Clob.Domain.Abstractions;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken);
}
