namespace PATTERNS.Bridge;

// Bridge: конкретная реализация — вывод в консоль/лог (Web-канал)
public class WebNotificationSender : INotificationSender
{
    public void Send(string title, string body, string recipient)
    {
        Console.WriteLine($"[WEB NOTIFICATION] To: {recipient}");
        Console.WriteLine($"  Title: {title}");
        Console.WriteLine($"  Body:  {body}");
    }
}