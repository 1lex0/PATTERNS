namespace PATTERNS.Interfaces;

public interface IThemeFactory
{
    IBackground CreateBackground();
    IButton CreateButton();
}