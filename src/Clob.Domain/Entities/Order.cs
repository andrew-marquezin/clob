using Clob.Domain.Enums;

namespace Clob.Domain.Entities;

public class Order(
    Guid id,
    Guid ownerId,
    OrderType type,
    OrderStatus status,
    decimal priceBrl,
    decimal priceBtc) : EntityBase(id)
{
    public Guid OwnerId { get; private set; } = ownerId;
    public OrderType Type { get; private set; } = type;
    public OrderStatus Status { get; private set; } = status;
    public decimal PriceBrl { get; private set; } = priceBrl;
    public decimal PriceBtc { get; private set; } = priceBtc;
}
