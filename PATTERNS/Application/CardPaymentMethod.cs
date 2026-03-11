using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class CardPaymentMethod : IPaymentMethod
{
    public string Name => "Card";
    public bool Pay(decimal amount) => amount > 0;
}