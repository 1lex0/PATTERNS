namespace PATTERNS.Lab3.Strategy;

public class PricingCalculator
{
    private IPricingStrategy _strategy;

    public PricingCalculator(IPricingStrategy strategy)
        {
            _strategy = strategy;
        }

    public void SetStrategy(IPricingStrategy strategy) => _strategy = strategy;

    public decimal Calculate(decimal basePrice, int nights, int guests)
        => _strategy.Calculate(basePrice, nights, guests);
}