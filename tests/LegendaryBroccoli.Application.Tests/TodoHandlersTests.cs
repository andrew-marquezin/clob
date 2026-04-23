using LegendaryBroccoli.Application.Features.Todos.Commands;
using LegendaryBroccoli.Application.Features.Todos.Queries;
using LegendaryBroccoli.Domain.Abstractions;
using LegendaryBroccoli.Domain.Entities;

namespace LegendaryBroccoli.Application.Tests;

public class TodoHandlersTests
{
    [Fact]
    public async Task CreateTodoCommand_ShouldPersistTodoWithTrimmedTitle()
    {
        var repository = new FakeTodoRepository();
        var handler = new CreateTodoCommandHandler(repository);

        var result = await handler.Handle(new CreateTodoCommand("  primeira tarefa  "));

        Assert.True(result.IsSuccess);
        var persisted = await repository.GetByIdAsync(result.Value);

        Assert.NotNull(persisted);
        Assert.Equal("primeira tarefa", persisted!.Title);
    }

    [Fact]
    public async Task CreateTodoCommand_ShouldReturnFailure_WhenTitleIsEmpty()
    {
        var repository = new FakeTodoRepository();
        var handler = new CreateTodoCommandHandler(repository);

        var result = await handler.Handle(new CreateTodoCommand("   "));

        Assert.True(result.IsFailure);
        Assert.Equal("Validation", result.Error.Code);
    }

    [Fact]
    public async Task GetTodoByIdQuery_ShouldReturnFailure_WhenTodoDoesNotExist()
    {
        var repository = new FakeTodoRepository();
        var handler = new GetTodoByIdQueryHandler(repository);

        var result = await handler.Handle(new GetTodoByIdQuery(Guid.NewGuid()));

        Assert.True(result.IsFailure);
        Assert.Equal("NotFound", result.Error.Code);
    }

    private sealed class FakeTodoRepository : ITodoRepository
    {
        private readonly Dictionary<Guid, TodoItem> _items = new();

        public Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
        {
            _items[todoItem.Id] = todoItem;
            return Task.CompletedTask;
        }

        public Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _items.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task<IReadOnlyCollection<TodoItem>> ListAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyCollection<TodoItem>>(_items.Values.ToArray());
    }
}
