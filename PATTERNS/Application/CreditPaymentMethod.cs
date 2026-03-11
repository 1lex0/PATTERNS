using PATTERNS.Interfaces;

namespace PATTERNS.Application;

    public class CreditPaymentMethod : IPaymentMethod
    {
    public string Name => "Credit";

    public bool Pay(decimal amount) => amount > 0;
}

