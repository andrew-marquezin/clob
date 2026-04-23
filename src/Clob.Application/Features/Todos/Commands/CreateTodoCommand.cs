using Clob.Application.Abstractions.Messaging;
using Clob.Domain.Abstractions;
using Clob.Domain.Entities;
using Clob.SharedKernel;

namespace Clob.Application.Features.Todos.Commands;

public sealed record CreateTodoCommand(string Title) : ICommand<Guid>;

public sealed class CreateTodoCommandHandler(ITodoRepository todoRepository) : ICommandHandler<CreateTodoCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTodoCommand command, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.Title))
        {
            return Result.Failure<Guid>(Error.Validation("Todo title is required."));
        }

        var todo = new TodoItem(Guid.NewGuid(), command.Title.Trim(), isCompleted: false, DateTimeOffset.UtcNow);

        await todoRepository.AddAsync(todo, cancellationToken);

        return Result.Success(todo.Id);
    }
}
