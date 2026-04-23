using Clob.Application.Abstractions.Messaging;
using Clob.Domain.Abstractions;
using Clob.SharedKernel;

namespace Clob.Application.Features.Todos.Queries;

public sealed record GetTodosQuery : IQuery<IReadOnlyCollection<TodoDto>>;

public sealed class GetTodosQueryHandler(ITodoRepository todoRepository) : IQueryHandler<GetTodosQuery, IReadOnlyCollection<TodoDto>>
{
    public async Task<Result<IReadOnlyCollection<TodoDto>>> Handle(GetTodosQuery query, CancellationToken cancellationToken = default)
    {
        var todos = await todoRepository.ListAsync(cancellationToken);

        var dtos = todos
            .OrderBy(todo => todo.CreatedAt)
            .Select(todo => new TodoDto(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt))
            .ToArray();

        return Result.Success<IReadOnlyCollection<TodoDto>>(dtos);
    }
}
