using Microsoft.AspNetCore.Mvc;
using PATTERNS.Lab3.ChainOfResponsibility;
using PATTERNS.Lab3.ChainOfResponsibility.Handlers;

namespace PATTERNS.Controllers;

public class AuthController : Controller
{
    private readonly AuthDbContext _db;

    public AuthController(AuthDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(AuthRequest request)
    {
        request.IsLogin = false;

        var chain = new EmailFormatHandler();
        chain.SetNext(new EmailUniqueHandler())
             .SetNext(new PasswordStrengthHandler())
             .SetNext(new PasswordConfirmHandler())
             .SetNext(new CreateUserHandler());

        chain.Handle(request, _db);

        if (!request.IsSuccess)
        {
            ViewBag.Error = request.ErrorMessage;
            return View(request);
        }

        HttpContext.Session.SetString("UserEmail", request.ResolvedUser!.Email);
        HttpContext.Session.SetString("UserName", request.ResolvedUser!.FullName);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(AuthRequest request)
    {
        request.IsLogin = true;

        var chain = new EmailFormatHandler();
        chain.SetNext(new EmailExistsHandler())
             .SetNext(new PasswordVerifyHandler())
             .SetNext(new SessionHandler());

        chain.Handle(request, _db);

        if (!request.IsSuccess)
        {
            ViewBag.Error = request.ErrorMessage;
            return View(request);
        }

        HttpContext.Session.SetString("UserEmail", request.ResolvedUser!.Email);
        HttpContext.Session.SetString("UserName", request.ResolvedUser!.FullName);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}