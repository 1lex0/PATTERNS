namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class EmailFormatHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        if (!request.Email.Contains("@") || !request.Email.Contains("."))
        {
            request.ErrorMessage = "Invalid email format.";
            return;
        }
        base.Handle(request, db);
    }
}