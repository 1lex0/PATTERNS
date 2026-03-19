using Microsoft.AspNetCore.Mvc;
using PATTERNS.Application;

namespace PATTERNS.Controllers;

public class ThemeController : Controller
{
    private readonly ThemeBlackFactory _blackFactory;
    private readonly ThemeLightFactory _lightFactory;

    public ThemeController(ThemeBlackFactory blackFactory, ThemeLightFactory lightFactory)
    {
        _blackFactory = blackFactory;
        _lightFactory = lightFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Preview(string theme)
    {
        var factory = theme == "dark"
            ? (PATTERNS.Interfaces.IThemeFactory)_blackFactory
            : _lightFactory;

        var background = factory.CreateBackground();
        var button = factory.CreateButton();

        ViewBag.ThemeName = theme == "dark" ? "ThemeBlack" : "ThemeLight";
        ViewBag.BackgroundColor = background.Color;
        ViewBag.BackgroundRender = background.Render();
        ViewBag.ButtonLabel = button.Label;
        ViewBag.ButtonRender = button.Render();

        return View();
    }
}