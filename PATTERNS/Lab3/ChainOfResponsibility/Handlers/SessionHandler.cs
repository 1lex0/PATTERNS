namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class SessionHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        request.IsSuccess = true;
    }
}