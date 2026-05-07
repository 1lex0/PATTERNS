namespace PATTERNS.Lab3.State;

public class CompletedState : IBookingState
{
    public string StateName => "Completed";
    public string StateColor => "#27ae60";
    public List<string> AvailableActions => new();

    public void Confirm(BookingContext context) { }
    public void CheckIn(BookingContext context) { }
    public void Complete(BookingContext context) { }
    public void Cancel(BookingContext context) { }
}