namespace PATTERNS.Lab3.ChainOfResponsibility;

public abstract class AuthHandler
{
    private AuthHandler? _next;

    public AuthHandler SetNext(AuthHandler next)
    {
        _next = next;
        return next;
    }

    public virtual void Handle(AuthRequest request, AuthDbContext db)
    {
        if (_next != null && request.ErrorMessage == null)
            _next.Handle(request, db);
    }
}