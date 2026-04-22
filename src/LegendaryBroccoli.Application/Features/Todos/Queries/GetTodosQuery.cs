using LegendaryBroccoli.Application.Abstractions.Messaging;
using LegendaryBroccoli.Application.Abstractions.Persistence;

namespace LegendaryBroccoli.Application.Features.Todos.Queries;

public sealed record GetTodosQuery : IQuery<IReadOnlyCollection<TodoDto>>;

public sealed class GetTodosQueryHandler(ITodoRepository todoRepository) : IQueryHandler<GetTodosQuery, IReadOnlyCollection<TodoDto>>
{
    public async Task<IReadOnlyCollection<TodoDto>> Handle(GetTodosQuery query, CancellationToken cancellationToken = default)
    {
        var todos = await todoRepository.ListAsync(cancellationToken);

        return todos
            .OrderBy(todo => todo.CreatedAt)
            .Select(todo => new TodoDto(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt))
            .ToArray();
    }
}
