namespace PATTERNS.Bridge;

// Bridge: конкретная абстракция — уведомление об успешном бронировании
public class BookingConfirmationNotification : BookingNotification
{
    private readonly string _bookingCode;
    private readonly string _hotelName;
    private readonly string _roomName;
    private readonly decimal _totalPrice;

    public BookingConfirmationNotification(
        INotificationSender sender,
        string bookingCode,
        string hotelName,
        string roomName,
        decimal totalPrice) : base(sender)
    {
        _bookingCode = bookingCode;
        _hotelName = hotelName;
        _roomName = roomName;
        _totalPrice = totalPrice;
    }

    public override void Notify(string recipient)
    {
        var title = "Booking Confirmed!";
        var body = $"Your booking is confirmed.\n\n" +
                   $"Code:   {_bookingCode}\n" +
                   $"Hotel:  {_hotelName}\n" +
                   $"Room:   {_roomName}\n" +
                   $"Total:  {_totalPrice} EUR";

        _sender.Send(title, body, recipient);
    }
}