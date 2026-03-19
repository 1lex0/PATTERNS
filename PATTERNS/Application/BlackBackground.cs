using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class BlackBackground : IBackground
{
    public string Color => "#1a1a1a";
    public string Render() => $"Background with color {Color}";
}