using Microsoft.EntityFrameworkCore;


namespace PATTERNS.Lab3.ChainOfResponsibility;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
}