using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class ConfirmationMessage : IConfirmationMessage
{
    public string Title { get; }
    public string Body { get; }

    public ConfirmationMessage(string title, string body)
    {
        Title = title;
        Body = body;
    }
}