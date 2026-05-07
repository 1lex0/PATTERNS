namespace PATTERNS.Bridge;

// Bridge: абстракция — тип уведомления, держит ссылку на реализацию (sender)
public abstract class BookingNotification
{
    protected readonly INotificationSender _sender;

    protected BookingNotification(INotificationSender sender)
    {
        _sender = sender;
    }

    // Каждый подкласс сам формирует сообщение и вызывает _sender.Send()
    public abstract void Notify(string recipient);
}