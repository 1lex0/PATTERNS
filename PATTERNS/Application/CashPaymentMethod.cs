using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class CashPaymentMethod : IPaymentMethod
{
    public string Name => "Cash";
    public bool Pay(decimal amount) => amount > 0;
}