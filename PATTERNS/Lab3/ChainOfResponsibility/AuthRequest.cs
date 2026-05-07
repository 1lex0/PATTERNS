namespace PATTERNS.Lab3.ChainOfResponsibility;

public class AuthRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
    public string FullName { get; set; } = "";
    public bool IsLogin { get; set; } = false;

    // Заполняется по ходу цепочки
    public User? ResolvedUser { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccess { get; set; } = false;
}