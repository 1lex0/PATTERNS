namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class PasswordStrengthHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        if (request.Password.Length < 6)
        {
            request.ErrorMessage = "Password must be at least 6 characters.";
            return;
        }
        base.Handle(request, db);
    }
}