using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// Abstract Factory — светлая тема
public class ThemeLightFactory : IThemeFactory
{
    public IBackground CreateBackground() => new LightBackground();
    public IButton CreateButton() => new LightButton();
}