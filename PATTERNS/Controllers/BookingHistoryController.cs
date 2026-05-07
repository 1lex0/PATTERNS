using Microsoft.AspNetCore.Mvc;
using PATTERNS.Lab3.Command;
using PATTERNS.Lab3.Command.Commands;

namespace PATTERNS.Controllers;

public class BookingHistoryController : Controller
{
    public IActionResult Index()
    {
        var bookings = BookingCommandStore.Storage.GetAll();
        var history = BookingCommandStore.Invoker.GetHistory();
        ViewBag.History = history;
        return View(bookings);
    }

    [HttpPost]
    public IActionResult Cancel(string bookingCode)
    {
        var command = new CancelBookingCommand(BookingCommandStore.Storage, bookingCode);
        BookingCommandStore.Invoker.ExecuteCommand(command);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Undo()
    {
        BookingCommandStore.Invoker.UndoLast();
        return RedirectToAction("Index");
    }
}