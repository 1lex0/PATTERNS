using Microsoft.AspNetCore.Mvc;
using PATTERNS.Composite;
using PATTERNS.Interfaces;

namespace PATTERNS.Controllers;

public class CompositeController : Controller
{
    private readonly IHotelRepository _repo;

    public CompositeController(IHotelRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index(string? hotelId)
    {
        var hotels = _repo.GetAllHotels();

        // Если отель не выбран — берём первый
        var selectedHotel = string.IsNullOrEmpty(hotelId)
            ? hotels.First()
            : hotels.FirstOrDefault(h => h.Id == hotelId) ?? hotels.First();

        // Строим Composite-дерево из данных репозитория
        var hotelComposite = BuildHotelComposite(selectedHotel);

        // Выводим в консоль для наглядности
        hotelComposite.Display();

        ViewBag.Hotels = hotels;
        ViewBag.SelectedHotelId = selectedHotel.Id;
        ViewBag.Hotel = hotelComposite;

        return View();
    }

    private HotelComposite BuildHotelComposite(Domain.Hotel hotel)
    {
        var hotelComposite = new HotelComposite(hotel.Name);

        // Группируем комнаты по этажам (по типу для простоты)
        // Floor 1 = Standard, Floor 2 = Deluxe, Floor 3 = Suite
        var floorMap = new Dictionary<string, (string floorName, int floorNum)>
        {
            { "Standard", ("Floor 1 — Standard", 1) },
            { "Deluxe",   ("Floor 2 — Deluxe", 2) },
            { "Suite",    ("Floor 3 — Suite", 3) }
        };

        foreach (var entry in floorMap)
        {
            var template = hotel.RoomTemplates.FirstOrDefault(t => t.Type.ToString() == entry.Key);
            if (template == null) continue;

            var floor = new FloorComposite(entry.Value.floorName);
            var floorNum = entry.Value.floorNum;

            // Создаём 3 комнаты на каждом этаже
            for (int i = 1; i <= 3; i++)
            {
                var roomNumber = $"Room {floorNum}0{i}";
                floor.Add(new RoomLeaf(roomNumber, entry.Key, template.PricePerNight, "free"));
            }

            hotelComposite.Add(floor);
        }

        return hotelComposite;
    }
}