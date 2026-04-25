namespace Clob.Domain.Entities;

public abstract class EntityBase(Guid id, DateTimeOffset createdAt)
{
    public Guid Id { get; } = id;
    public DateTimeOffset CreatedAt { get; } = createdAt;
}
