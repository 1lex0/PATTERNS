namespace PATTERNS.Application;

// Имитация внешнего PayPal SDK — у него свой метод ExecutePayment, не Pay()
public class ExternalPayPalGateway
{
    private readonly string _apiKey;

    public ExternalPayPalGateway(string apiKey = "paypal-demo-key-12345")
    {
        _apiKey = apiKey;
    }

    public bool ExecutePayment(double amountUsd)
    {
        // Имитация вызова внешнего API
        Console.WriteLine($"[PayPal] Executing payment of ${amountUsd} via key: {_apiKey}");
        return amountUsd > 0;
    }

    public string GetTransactionId()
    {
        return $"PP-{Guid.NewGuid().ToString()[..8].ToUpper()}";    
    }
}