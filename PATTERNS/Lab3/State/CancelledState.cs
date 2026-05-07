namespace PATTERNS.Lab3.State;

public class CancelledState : IBookingState
{
    public string StateName => "Cancelled";
    public string StateColor => "#e74c3c";
    public List<string> AvailableActions => new();

    public void Confirm(BookingContext context) { }
    public void CheckIn(BookingContext context) { }
    public void Complete(BookingContext context) { }
    public void Cancel(BookingContext context) { }
}