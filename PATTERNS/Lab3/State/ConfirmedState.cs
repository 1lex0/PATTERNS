namespace PATTERNS.Lab3.State;

public class ConfirmedState : IBookingState
{
    public string StateName => "Confirmed";
    public string StateColor => "#2e86de";
    public List<string> AvailableActions => new() { "CheckIn", "Cancel" };

    public void Confirm(BookingContext context) { }
    public void CheckIn(BookingContext context) => context.State = new CheckedInState();
    public void Complete(BookingContext context) { }
    public void Cancel(BookingContext context) => context.State = new CancelledState();
}