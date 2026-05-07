namespace PATTERNS.Lab3.Command.Commands;

public class CreateBookingCommand : ICommand
{
    private readonly BookingStorage _storage;
    private readonly BookingRecord _record;

    public string CommandName => "Create Booking";
    public string Description => $"Created booking {_record.BookingCode} for {_record.GuestName}";

    public CreateBookingCommand(BookingStorage storage, BookingRecord record)
    {
        _storage = storage;
        _record = record;
    }

    public void Execute() => _storage.Add(_record);

    public void Undo() => _record.IsCancelled = true;
}