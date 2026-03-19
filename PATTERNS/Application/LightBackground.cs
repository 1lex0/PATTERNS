using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class LightBackground : IBackground
{
    public string Color => "#ffffff";
    public string Render() => $"Background with color {Color}";
}