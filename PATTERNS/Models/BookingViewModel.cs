using Microsoft.AspNetCore.Mvc.Rendering;
using PATTERNS.Domain;
using PATTERNS.Interfaces;

namespace PATTERNS.Models;

public class BookingViewModel
{
    public string HotelId { get; set; } = "";
    public RoomType RoomType { get; set; } = RoomType.Standard;

    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public int Guests { get; set; } = 1;

    public string PaymentType { get; set; } = "Card";

    // Для dropdown-ов
    public List<SelectListItem> Hotels { get; set; } = new();
    public List<SelectListItem> PaymentTypes { get; set; } = new()
    {
        new SelectListItem("Card", "Card"),
        new SelectListItem("Cash", "Cash"),
        new SelectListItem("Crypto", "Crypto"),
        new SelectListItem("Credit", "Credit"),
        new SelectListItem("Mdl", "Mdl")
    };
}