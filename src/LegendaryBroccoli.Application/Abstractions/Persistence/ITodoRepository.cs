using LegendaryBroccoli.Domain.Entities;

namespace LegendaryBroccoli.Application.Abstractions.Persistence;

public interface ITodoRepository
{
    Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default);

    Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TodoItem>> ListAsync(CancellationToken cancellationToken = default);
}
