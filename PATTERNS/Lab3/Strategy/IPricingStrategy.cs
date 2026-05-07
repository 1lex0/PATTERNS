namespace PATTERNS.Lab3.Strategy;

public interface IPricingStrategy
{
    string Name { get; }
    string Description { get; }
    decimal Calculate(decimal basePrice, int nights, int guests);
}