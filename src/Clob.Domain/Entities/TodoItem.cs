namespace Clob.Domain.Entities;

public class TodoItem
{
    public TodoItem(Guid id, string title, bool isCompleted, DateTimeOffset createdAt)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }

    public string Title { get; }

    public bool IsCompleted { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public void MarkAsCompleted() => IsCompleted = true;
}
