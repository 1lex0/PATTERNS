namespace PATTERNS.Lab3.ChainOfResponsibility.Handlers;

public class CreateUserHandler : AuthHandler
{
    public override void Handle(AuthRequest request, AuthDbContext db)
    {
        var user = new User
        {
            Email = request.Email,
            FullName = request.FullName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };
        db.Users.Add(user);
        db.SaveChanges();
        request.ResolvedUser = user;
        request.IsSuccess = true;
    }
}