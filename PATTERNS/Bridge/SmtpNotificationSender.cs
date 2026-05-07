using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace PATTERNS.Bridge;

public class SmtpNotificationSender : INotificationSender
{
    private readonly string _fromEmail;
    private readonly string _appPassword;

    public SmtpNotificationSender(string fromEmail, string appPassword)
    {
        _fromEmail = fromEmail;
        _appPassword = appPassword;
    }

    public void Send(string title, string body, string recipient)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_fromEmail));
            email.To.Add(MailboxAddress.Parse(recipient));
            email.Subject = title;
            email.Body = new TextPart("plain") { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 465, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_fromEmail, _appPassword);
            smtp.Send(email);
            smtp.Disconnect(true);

            Console.WriteLine($"[SMTP] Email sent to {recipient}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SMTP ERROR] {ex.Message}");
        }
    }
}