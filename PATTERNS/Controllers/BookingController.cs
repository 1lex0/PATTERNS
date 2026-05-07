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
    private readonly IBookingFacade _facade;  // Facade вместо кучи зависимостей

    public BookingController(IHotelRepository repo, IBookingFacade facade)
    {
        _repo = repo;
        _facade = facade;
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
        vm.Hotels = _repo.GetAllHotels()
            .Select(h => new SelectListItem(h.Name, h.Id))
            .ToList();

        // Facade: ОДИН вызов — внутри: создание брони + оплата + уведомления
        var guestName = HttpContext.Session.GetString("UserName") ?? "Guest";

        var (booking, message) = _facade.CreateBookingWithNotification(
            vm.HotelId,
            vm.RoomType,
            vm.CheckIn,
            vm.CheckOut,
            vm.Guests,
            vm.PaymentType,
            guestName
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