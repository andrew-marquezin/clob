namespace Clob.Application.Features.Accounts;

public class GetBalanceOutput(decimal balanceBrl, decimal balanceBtc)
{
    public decimal BalanceBrl { get; set; } = balanceBrl;
    public decimal BalanceBtc { get; set; } = balanceBtc;
}
