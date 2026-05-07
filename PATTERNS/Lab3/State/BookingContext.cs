namespace PATTERNS.Lab3.State;

public class BookingContext
{
    public string BookingId { get; set; } = "";
    public string GuestName { get; set; } = "";
    public string HotelName { get; set; } = "";
    public string RoomType { get; set; } = "";
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public double TotalPrice { get; set; }
    public IBookingState State { get; set; } = new PendingState();

    public void Confirm() => State.Confirm(this);
    public void CheckInGuest() => State.CheckIn(this);
    public void Complete() => State.Complete(this);
    public void Cancel() => State.Cancel(this);
}