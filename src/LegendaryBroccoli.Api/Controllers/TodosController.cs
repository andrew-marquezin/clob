using LegendaryBroccoli.Application.Abstractions.Messaging;
using LegendaryBroccoli.Application.Features.Todos;
using LegendaryBroccoli.Application.Features.Todos.Commands;
using LegendaryBroccoli.Application.Features.Todos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LegendaryBroccoli.Api.Controllers;

[ApiController]
[Route("todos")]
public class TodosController(
    ICommandHandler<CreateTodoCommand, Guid> createHandler,
    IQueryHandler<GetTodosQuery, IReadOnlyCollection<TodoDto>> getTodosHandler,
    IQueryHandler<GetTodoByIdQuery, TodoDto?> getByIdHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTodo(
        [FromBody] CreateTodoCommand command,
        CancellationToken cancellationToken)
    {
        var result = await createHandler.Handle(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(new { result.Error.Code, result.Error.Description });
        }

        return CreatedAtAction(nameof(GetTodoById), new { id = result.Value }, new { id = result.Value });
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos(CancellationToken cancellationToken)
    {
        var result = await getTodosHandler.Handle(new GetTodosQuery(), cancellationToken);

        if (result.IsFailure)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { result.Error.Code, result.Error.Description });
        }

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTodoById(Guid id, CancellationToken cancellationToken)
    {
        var result = await getByIdHandler.Handle(new GetTodoByIdQuery(id), cancellationToken);

        if (result.IsFailure)
        {
            return NotFound(new { result.Error.Code, result.Error.Description });
        }

        return Ok(result.Value);
    }
}
