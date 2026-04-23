using System.Collections.Concurrent;
using LegendaryBroccoli.Domain.Abstractions;
using LegendaryBroccoli.Domain.Entities;

namespace LegendaryBroccoli.Infrastructure.Persistence;

public sealed class InMemoryTodoRepository : ITodoRepository
{
    private readonly ConcurrentDictionary<Guid, TodoItem> _todos = new();

    public Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        _todos[todoItem.Id] = todoItem;
        return Task.CompletedTask;
    }

    public Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _todos.TryGetValue(id, out var todo);
        return Task.FromResult(todo);
    }

    public Task<IReadOnlyCollection<TodoItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyCollection<TodoItem>>(_todos.Values.ToArray());
    }
}
