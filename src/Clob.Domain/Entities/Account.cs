namespace Clob.Domain.Entities;

public class Account(Guid id, decimal balanceBtc, decimal balanceBrl) : EntityBase(id)
{
    public decimal BalanceBtc { get; private set; } = balanceBtc;
    public decimal BalanceBrl { get; private set; } = balanceBrl;
}
