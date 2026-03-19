using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class BlackButton : IButton  
{
    public string Label => "Dark Button";
    public string Render() => $"Button [{Label}] on dark theme";
}