namespace PATTERNS.Lab3.Command;

public class BookingStorage
{
    private readonly List<BookingRecord> _bookings = new();

    public IReadOnlyList<BookingRecord> GetAll() => _bookings;

    public void Add(BookingRecord record) => _bookings.Add(record);

    public BookingRecord? GetByCode(string code) =>
        _bookings.FirstOrDefault(b => b.BookingCode == code);
}