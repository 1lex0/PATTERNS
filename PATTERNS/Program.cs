using PATTERNS.Application;
using PATTERNS.Infrastructure;
using PATTERNS.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Singleton: отдаём один и тот же репозиторий всем
builder.Services.AddSingleton<IHotelRepository>(_ => InMemoryHotelRepository.Instance);

// Factory / Services
builder.Services.AddSingleton<PaymentMethodFactory>();
builder.Services.AddSingleton<IUiFactory, WebUiFactory>();
// Theme Abstract Factories
builder.Services.AddTransient<ThemeBlackFactory>();
builder.Services.AddTransient<ThemeLightFactory>();
builder.Services.AddSingleton<BookingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Стартовая страница ? Booking/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Index}/{id?}");

app.Run();