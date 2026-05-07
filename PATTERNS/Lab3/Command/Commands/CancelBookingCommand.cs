namespace PATTERNS.Lab3.Command.Commands;

public class CancelBookingCommand : ICommand
{
    private readonly BookingStorage _storage;
    private readonly string _bookingCode;
    private BookingRecord? _cancelledRecord;

    public string CommandName => "Cancel Booking";
    public string Description => $"Cancelled booking {_bookingCode}";

    public CancelBookingCommand(BookingStorage storage, string bookingCode)
    {
        _storage = storage;
        _bookingCode = bookingCode;
    }

    public void Execute()
    {
        _cancelledRecord = _storage.GetByCode(_bookingCode);
        if (_cancelledRecord != null)
            _cancelledRecord.IsCancelled = true;
    }

    public void Undo()
    {
        if (_cancelledRecord != null)
            _cancelledRecord.IsCancelled = false;
    }
}