namespace PATTERNS.Bridge;

// Bridge: интерфейс реализации (канал доставки)
public interface INotificationSender
{
    void Send(string title, string body, string recipient);
}