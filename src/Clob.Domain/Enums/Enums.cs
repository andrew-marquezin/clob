namespace Clob.Domain.Enums;

public enum OrderType
{
    Sell = 0,
    Buy = 1
}

public enum OrderStatus
{
    Cancelled = 0,
    Created = 1,
    Completed = 2,
    Processing = 3
}
