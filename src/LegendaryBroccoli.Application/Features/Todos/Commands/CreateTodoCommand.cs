using LegendaryBroccoli.Application.Abstractions.Messaging;
using LegendaryBroccoli.Application.Abstractions.Persistence;
using LegendaryBroccoli.Domain.Entities;

namespace LegendaryBroccoli.Application.Features.Todos.Commands;

public sealed record CreateTodoCommand(string Title) : ICommand<Guid>;

public sealed class CreateTodoCommandHandler(ITodoRepository todoRepository) : ICommandHandler<CreateTodoCommand, Guid>
{
    public async Task<Guid> Handle(CreateTodoCommand command, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.Title))
        {
            throw new ArgumentException("Todo title is required.", nameof(command));
        }

        var todo = new TodoItem(Guid.NewGuid(), command.Title.Trim(), isCompleted: false, DateTimeOffset.UtcNow);

        await todoRepository.AddAsync(todo, cancellationToken);

        return todo.Id;
    }
}
