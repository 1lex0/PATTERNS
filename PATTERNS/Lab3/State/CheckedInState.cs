namespace PATTERNS.Lab3.State;

public class CheckedInState : IBookingState
{
    public string StateName => "Checked In";
    public string StateColor => "#8e44ad";
    public List<string> AvailableActions => new() { "Complete" };

    public void Confirm(BookingContext context) { }
    public void CheckIn(BookingContext context) { }
    public void Complete(BookingContext context) => context.State = new CompletedState();
    public void Cancel(BookingContext context) { }
}