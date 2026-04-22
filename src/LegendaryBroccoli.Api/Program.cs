using LegendaryBroccoli.Application.Features.Todos.Commands;
using LegendaryBroccoli.Application.Features.Todos.Queries;
using LegendaryBroccoli.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddTransient<CreateTodoCommandHandler>();
builder.Services.AddTransient<GetTodoByIdQueryHandler>();
builder.Services.AddTransient<GetTodosQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/todos", async (CreateTodoCommand request, CreateTodoCommandHandler handler, CancellationToken cancellationToken) =>
{
    var id = await handler.Handle(request, cancellationToken);
    return Results.Created($"/todos/{id}", new { id });
});

app.MapGet("/todos", async (GetTodosQueryHandler handler, CancellationToken cancellationToken) =>
{
    var todos = await handler.Handle(new GetTodosQuery(), cancellationToken);
    return Results.Ok(todos);
});

app.MapGet("/todos/{id:guid}", async (Guid id, GetTodoByIdQueryHandler handler, CancellationToken cancellationToken) =>
{
    var todo = await handler.Handle(new GetTodoByIdQuery(id), cancellationToken);
    return todo is null ? Results.NotFound() : Results.Ok(todo);
});

app.Run();
