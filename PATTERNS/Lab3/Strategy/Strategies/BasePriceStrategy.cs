namespace PATTERNS.Lab3.Strategy.Strategies;

public class BasePriceStrategy : IPricingStrategy
{
    public string Name => "Base Price";
    public string Description => "Standard price — no discounts or surcharges applied.";

    public decimal Calculate(decimal basePrice, int nights, int guests)
        => basePrice * nights;
}