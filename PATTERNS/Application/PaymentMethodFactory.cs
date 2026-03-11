using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// Factory Method ///////

public class PaymentMethodFactory
{
    public IPaymentMethod Create(string paymentType)
    {
        return paymentType.Trim().ToLowerInvariant() switch
        {
            "card" => new CardPaymentMethod(),
            "cash" => new CashPaymentMethod(),
            "crypto" => new CryptoPaymentMethod(),
            "credit" => new CreditPaymentMethod(),
            _ => throw new ArgumentException("Unknown payment type. Use: Card, Cash, Crypto, Credit.")
        };
    }
}