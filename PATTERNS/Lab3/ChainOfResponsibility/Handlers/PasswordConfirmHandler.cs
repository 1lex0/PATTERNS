namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class PasswordConfirmHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        if (request.Password != request.ConfirmPassword)
        {
            request.ErrorMessage = "Passwords do not match.";
            return;
        }
        base.Handle(request, db);
    }
}