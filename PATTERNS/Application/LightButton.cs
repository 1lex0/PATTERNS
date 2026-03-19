using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class LightButton : IButton
{
    public string Label => "Light Button";
    public string Render() => $"Button [{Label}] on light theme";
}