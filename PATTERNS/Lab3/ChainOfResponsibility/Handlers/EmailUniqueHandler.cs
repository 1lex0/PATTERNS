namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class EmailUniqueHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        if (db.Users.Any(u => u.Email == request.Email))
        {
            request.ErrorMessage = "This email is already registered.";
            return;
        }
        base.Handle(request, db);
    }
}