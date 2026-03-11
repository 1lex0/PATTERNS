using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PATTERNS.Application;
using PATTERNS.Domain;
using PATTERNS.Interfaces;
using PATTERNS.Models;

namespace PATTERNS.Controllers;

public class BookingController : Controller
{
    private readonly IHotelRepository _repo;
    private readonly BookingService _service;

    public BookingController(IHotelRepository repo, BookingService service)
    {
        _repo = repo;
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var vm = new BookingViewModel
        {
            CheckIn = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            CheckOut = DateOnly.FromDateTime(DateTime.Today.AddDays(2))
        };

        vm.Hotels = _repo.GetAllHotels()
            .Select(h => new SelectListItem(h.Name, h.Id))
            .ToList();

        return View(vm);
    }

    [HttpPost]
    public IActionResult Index(BookingViewModel vm)
    {
        // перезаполняем dropdown отелей (иначе пусто после POST)
        vm.Hotels = _repo.GetAllHotels()
            .Select(h => new SelectListItem(h.Name, h.Id))
            .ToList();

        var (booking, message) = _service.CreateBooking(
            vm.HotelId,
            vm.RoomType,
            vm.CheckIn,
            vm.CheckOut,
            vm.Guests,
            vm.PaymentType
        );

        if (booking is null)
        {
            ViewBag.ErrorTitle = message.Title;
            ViewBag.ErrorBody = message.Body;
            return View(vm);
        }

        ViewBag.MessageTitle = message.Title;
        ViewBag.MessageBody = message.Body;

        return View("Result", booking);
    }
}