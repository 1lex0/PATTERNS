namespace PATTERNS.Lab3.Command;

public static class BookingCommandStore
{
    public static BookingStorage Storage { get; } = new();
    public static BookingInvoker Invoker { get; } = new();
}