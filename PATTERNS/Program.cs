using Microsoft.EntityFrameworkCore;
using PATTERNS.Application;
using PATTERNS.Infrastructure;
using PATTERNS.Interfaces;
using PATTERNS.Lab3.ChainOfResponsibility;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Lab3 - Chain of Responsibility (Auth + SQLite)
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlite("Data Source=auth.db"));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Singleton: отдаём один и тот же репозиторий всем
builder.Services.AddSingleton<IHotelRepository>(_ => InMemoryHotelRepository.Instance);

// Factory / Services
builder.Services.AddSingleton<PaymentMethodFactory>();
builder.Services.AddSingleton<IUiFactory, WebUiFactory>();

// Theme Abstract Factories
builder.Services.AddTransient<ThemeBlackFactory>();
builder.Services.AddTransient<ThemeLightFactory>();
builder.Services.AddSingleton<BookingService>();
builder.Services.AddSingleton<BookingFacade>();

builder.Services.AddSingleton<BookingFacade>();

// Proxy (Logging): оборачивает BookingFacade логированием в файл
builder.Services.AddSingleton<IBookingFacade>(sp =>
    new LoggingBookingServiceProxy(
        sp.GetRequiredService<BookingFacade>(),
        sp.GetRequiredService<IWebHostEnvironment>()
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

// Стартовая страница ? Booking/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();