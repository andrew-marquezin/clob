namespace LegendaryBroccoli.Application.Features.Todos;

public sealed record TodoDto(Guid Id, string Title, bool IsCompleted, DateTimeOffset CreatedAt);
