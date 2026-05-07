namespace PATTERNS.Lab3.Strategy.Strategies;

public class SeasonalSurchargeStrategy : IPricingStrategy
{
    public string Name => "Seasonal Surcharge";
    public string Description => "Peak season — 30% surcharge applied to base price.";

    public decimal Calculate(decimal basePrice, int nights, int guests)
        => basePrice * nights * 1.30m;
}