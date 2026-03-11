namespace PATTERNS.Interfaces;

public interface IPaymentMethod
{
    string Name { get; }
    bool Pay(decimal amount);
}