namespace PATTERNS.Lab3.State;

public static class BookingStateStore
{
    private static readonly List<BookingContext> _bookings = new();

    public static List<BookingContext> GetAll() => _bookings;

    public static BookingContext? GetById(string id) =>
        _bookings.FirstOrDefault(b => b.BookingId == id);

    public static void Add(BookingContext context) => _bookings.Add(context);
}