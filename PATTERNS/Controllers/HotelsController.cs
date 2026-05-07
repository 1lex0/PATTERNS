using Microsoft.AspNetCore.Mvc;
using PATTERNS.Interfaces;
using PATTERNS.Lab3.Observer;

namespace PATTERNS.Controllers;

public class HotelsController : Controller
{
    private readonly IHotelRepository _repository;

    public HotelsController(IHotelRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var subject = new HotelFilterSubject(_repository);
        var observer = new HotelListObserver();
        subject.Subscribe(observer);
        subject.Notify();

        ViewBag.Districts = _repository.GetAllHotels()
            .Select(h => h.District)
            .Distinct()
            .OrderBy(d => d)
            .ToList();

        ViewBag.Amenities = _repository.GetAllHotels()
            .SelectMany(h => h.Amenities)
            .Distinct()
            .OrderBy(a => a)
            .ToList();

        return View(observer.Hotels);
    }

    [HttpPost]
    public IActionResult Filter([FromBody] HotelFilterRequest request)
    {
        var subject = new HotelFilterSubject(_repository)
        {
            District = request.District ?? "",
            MaxPrice = request.MaxPrice == 0 ? 9999 : request.MaxPrice,
            MinStars = request.MinStars,
            RequiredAmenities = request.Amenities ?? new List<string>()
        };

        var observer = new HotelListObserver();
        subject.Subscribe(observer);
        subject.Notify();

        return Json(observer.Hotels);
    }
}   