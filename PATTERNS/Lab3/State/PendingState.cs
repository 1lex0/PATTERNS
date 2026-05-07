namespace PATTERNS.Lab3.State;

public class PendingState : IBookingState
{
    public string StateName => "Pending";
    public string StateColor => "#e8a020";
    public List<string> AvailableActions => new() { "Confirm", "Cancel" };

    public void Confirm(BookingContext context) => context.State = new ConfirmedState();
    public void CheckIn(BookingContext context) { }
    public void Complete(BookingContext context) { }
    public void Cancel(BookingContext context) => context.State = new CancelledState();
}