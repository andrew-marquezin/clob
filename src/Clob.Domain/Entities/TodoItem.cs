namespace Clob.Domain.Entities;

public class TodoItem(Guid id, string title, bool isCompleted, DateTimeOffset createdAt) : EntityBase(id, createdAt)
{
    public string Title { get; } = title;

    public bool IsCompleted { get; private set; } = isCompleted;

    public void MarkAsCompleted() => IsCompleted = true;
}
