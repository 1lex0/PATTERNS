namespace PATTERNS.Lab3.State;

public interface IBookingState
{
    string StateName { get; }
    string StateColor { get; }
    List<string> AvailableActions { get; }
    void Confirm(BookingContext context);
    void CheckIn(BookingContext context);
    void Complete(BookingContext context);
    void Cancel(BookingContext context);
}