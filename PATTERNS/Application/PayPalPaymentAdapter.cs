using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// Adapter: адаптирует ExternalPayPalGateway под интерфейс IPaymentMethod
public class PayPalPaymentAdapter : IPaymentMethod
{
    private readonly ExternalPayPalGateway _payPal;
    private string _lastTransactionId = "";

    public PayPalPaymentAdapter()
    {
        _payPal = new ExternalPayPalGateway();
    }

    
    public string Name => $"PayPal (tx: {_lastTransactionId})";

   
    public bool Pay(decimal amount)
    {
        // Конвертируем decimal → double (несовместимые типы — именно здесь адаптация)
        var result = _payPal.ExecutePayment((double)amount);
        if (result)
            _lastTransactionId = _payPal.GetTransactionId();
        return result;
    }
}