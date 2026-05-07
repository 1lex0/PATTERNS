using Microsoft.AspNetCore.Mvc;
using PATTERNS.Interfaces;
using PATTERNS.Lab3.Strategy;
using PATTERNS.Lab3.Strategy.Strategies;

namespace PATTERNS.Controllers;

public class PricingController : Controller
{
    private readonly IHotelRepository _repo;

    public PricingController(IHotelRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        ViewBag.Hotels = _repo.GetAllHotels().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Calculate([FromBody] PricingRequest request)
    {
        var hotel = _repo.GetHotelById(request.HotelId);
        if (hotel == null) return Json(new { error = "Hotel not found" });

        var template = hotel.RoomTemplates.FirstOrDefault(r => r.Type.ToString() == request.RoomType);
        if (template == null) return Json(new { error = "Room not found" });

        IPricingStrategy pricingStrategy = request.Strategy switch
        {
            "seasonal" => new SeasonalSurchargeStrategy(),
            "loyalty" => new LoyaltyDiscountStrategy(),
            "lastminute" => new LastMinuteDealStrategy(),
            _ => new BasePriceStrategy()
        };

        var calculator = new PricingCalculator(pricingStrategy);
        var total = calculator.Calculate(template.PricePerNight, request.Nights, request.Guests);

        return Json(new
        {
            strategyName = pricingStrategy.Name,
            strategyDescription = pricingStrategy.Description,
            basePrice = template.PricePerNight,
            nights = request.Nights,
            guests = request.Guests,
            total = Math.Round(total, 2)
        });
    }
}