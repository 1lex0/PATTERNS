using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// Abstract Factory — тёмная тема
public class ThemeBlackFactory : IThemeFactory
{
    public IBackground CreateBackground() => new BlackBackground();
    public IButton CreateButton() => new BlackButton();
}