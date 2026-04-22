using LegendaryBroccoli.Application.Abstractions.Messaging;
using LegendaryBroccoli.Application.Abstractions.Persistence;

namespace LegendaryBroccoli.Application.Features.Todos.Queries;

public sealed record GetTodoByIdQuery(Guid Id) : IQuery<TodoDto?>;

public sealed class GetTodoByIdQueryHandler(ITodoRepository todoRepository) : IQueryHandler<GetTodoByIdQuery, TodoDto?>
{
    public async Task<TodoDto?> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken = default)
    {
        var todo = await todoRepository.GetByIdAsync(query.Id, cancellationToken);

        return todo is null
            ? null
            : new TodoDto(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt);
    }
}
