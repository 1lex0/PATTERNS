namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class PasswordVerifyHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        if (request.ResolvedUser == null ||
            !BCrypt.Net.BCrypt.Verify(request.Password, request.ResolvedUser.PasswordHash))
        {
            request.ErrorMessage = "Incorrect password.";
            return;
        }
        base.Handle(request, db);
    }
}