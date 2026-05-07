namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class EmailExistsHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        var user = db.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
        {
            request.ErrorMessage = "No account found with this email.";
            return;
        }
        request.ResolvedUser = user;
        base.Handle(request, db);
    }
}