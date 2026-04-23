using Clob.Application.Abstractions.Messaging;
using Clob.Domain.Abstractions;
using Clob.SharedKernel;

namespace Clob.Application.Features.Todos.Queries;

public sealed record GetTodoByIdQuery(Guid Id) : IQuery<TodoDto?>;

public sealed class GetTodoByIdQueryHandler(ITodoRepository todoRepository) : IQueryHandler<GetTodoByIdQuery, TodoDto?>
{
    public async Task<Result<TodoDto?>> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken = default)
    {
        var todo = await todoRepository.GetByIdAsync(query.Id, cancellationToken);

        if (todo is null)
        {
            return Result.Failure<TodoDto?>(Error.NotFound($"Todo with id '{query.Id}' was not found."));
        }

        return Result.Success<TodoDto?>(new TodoDto(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt));
    }
}
