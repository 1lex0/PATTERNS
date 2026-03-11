using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;
using HotelBooking.Interfaces;
using HotelBooking.Domain;
using HotelBooking.Application;
using System;

namespace HotelBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly BookingService _bookingService;
        private readonly IUiFactory _uiFactory;

        public BookingController(IHotelRepository hotelRepository, BookingService bookingService, IUiFactory uiFactory)
        {
            _hotelRepository = hotelRepository;
            _bookingService = bookingService;
            _uiFactory = uiFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new BookingViewModel
            {
                Hotels = new List<Hotel>(_hotelRepository.GetHotels()),
                CheckIn = DateTime.Today.AddDays(1),
                CheckOut = DateTime.Today.AddDays(2),
                Guests = 1
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BookingViewModel model)
        {
            if (model.CheckIn >= model.CheckOut)
            {
                var errorMsg = _uiFactory.CreateErrorMessage("Check-out must be after check-in.");
                ViewBag.Message = errorMsg.Message;
                model.Hotels = new List<Hotel>(_hotelRepository.GetHotels());
                return View(model);
            }

            var booking = _bookingService.CreateBooking(
                model.SelectedHotelId,
                model.SelectedRoomType,
                model.CheckIn,
                model.CheckOut,
                model.Guests,
                model.PaymentType);

            if (booking == null)
            {
                var errorMsg = _uiFactory.CreateErrorMessage("Booking failed. Please check your input.");
                ViewBag.Message = errorMsg.Message;
                model.Hotels = new List<Hotel>(_hotelRepository.GetHotels());
                return View(model);
            }

            var successMsg = _uiFactory.CreateSuccessMessage(booking.ConfirmationNumber, booking.TotalPrice);
            TempData["ConfirmationMessage"] = successMsg.Message;
            TempData["Booking"] = System.Text.Json.JsonSerializer.Serialize(booking);

            return RedirectToAction("Result");
        }

        [HttpGet]
        public IActionResult Result()
        {
            var message = TempData["ConfirmationMessage"] as string ?? "";
            var bookingJson = TempData["Booking"] as string;
            Booking? booking = null;
            if (bookingJson != null)
            {
                booking = System.Text.Json.JsonSerializer.Deserialize<Booking>(bookingJson);
            }
            return View((message, booking));
        }
    }
}
