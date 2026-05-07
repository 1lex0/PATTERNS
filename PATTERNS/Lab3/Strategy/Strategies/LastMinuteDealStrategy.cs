namespace PATTERNS.Lab3.Strategy.Strategies;

public class LastMinuteDealStrategy : IPricingStrategy
{
    public string Name => "Last Minute Deal";
    public string Description => "Book within 24h — 25% discount but only for 1-2 guests.";

    public decimal Calculate(decimal basePrice, int nights, int guests)
    {
        if (guests > 2) return basePrice * nights;
        return basePrice * nights * 0.75m;
    }
}