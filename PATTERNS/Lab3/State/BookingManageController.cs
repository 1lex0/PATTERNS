using Microsoft.AspNetCore.Mvc;
using PATTERNS.Lab3.State;

namespace PATTERNS.Controllers;

public class BookingManageController : Controller
{
    public IActionResult Index()
    {
        return View(BookingStateStore.GetAll());
    }

    [HttpPost]
    public IActionResult Action(string bookingId, string action)
    {
        var booking = BookingStateStore.GetById(bookingId);
        if (booking == null) return NotFound();

        switch (action)
        {
            case "Confirm": booking.Confirm(); break;
            case "CheckIn": booking.CheckInGuest(); break;
            case "Complete": booking.Complete(); break;
            case "Cancel": booking.Cancel(); break;
        }

        return RedirectToAction("Index");
    }
}