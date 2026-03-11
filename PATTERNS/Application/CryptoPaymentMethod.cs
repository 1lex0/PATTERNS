using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class CryptoPaymentMethod : IPaymentMethod
{
    public string Name => "Crypto";
    public bool Pay(decimal amount) => amount > 0;
}