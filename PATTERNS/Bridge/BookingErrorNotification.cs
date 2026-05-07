namespace PATTERNS.Bridge;

// Bridge: конкретная абстракция — уведомление об ошибке
public class BookingErrorNotification : BookingNotification
{
    private readonly string _errorMessage;

    public BookingErrorNotification(
        INotificationSender sender,
        string errorMessage) : base(sender)
    {
        _errorMessage = errorMessage;
    }

    public override void Notify(string recipient)
    {
        var title = "Booking Failed";
        var body = $"Unfortunately your booking could not be completed.\n\n" +
                   $"Reason: {_errorMessage}";

        _sender.Send(title, body, recipient);
    }
}