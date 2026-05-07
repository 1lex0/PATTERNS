namespace PATTERNS.Lab3.Strategy.Strategies;

public class LoyaltyDiscountStrategy : IPricingStrategy
{
    public string Name => "Loyalty Discount";
    public string Description => "Returning guest — 15% discount on base price.";

    public decimal Calculate(decimal basePrice, int nights, int guests)
        => basePrice * nights * 0.85m;
}