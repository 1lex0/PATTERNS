using PATTERNS.Domain;
using PATTERNS.Interfaces;

namespace PATTERNS.Infrastructure;

// SINGLETON ///////////////
public sealed class InMemoryHotelRepository : IHotelRepository
{
    private static readonly Lazy<InMemoryHotelRepository> _instance =
        new(() => new InMemoryHotelRepository());
    public static InMemoryHotelRepository Instance => _instance.Value;

    private readonly List<Hotel> _hotels;

    private InMemoryHotelRepository()
    {
        _hotels = new List<Hotel>
        {
            new Hotel
            {
                Id = "H1",
                Name = "Aurora Grand Hotel",
                District = "City Center",
                PricePerNight = 80,
                Floors = 12,
                Stars = 5,
                Description = "Premium rooms with world-class service in the heart of the city.",
                Amenities = new List<string> { "WiFi", "Pool", "Gym", "Coffee", "Kettle", "Parking" },
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Room", PricePerNight = 80m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Room",   PricePerNight = 120m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Suite",         PricePerNight = 200m }
                }
            },
            new Hotel
            {
                Id = "H2",
                Name = "SeaMoon Resort",
                District = "Seaside",
                PricePerNight = 95,
                Floors = 8,
                Stars = 4,
                Description = "Breathtaking sea views and relaxing atmosphere by the coast.",
                Amenities = new List<string> { "WiFi", "Pool", "Coffee", "Kettle", "Beach Access" },
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Sea View", PricePerNight = 95m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Sea View",   PricePerNight = 145m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Ocean Suite",        PricePerNight = 240m }
                }
            },
            new Hotel
            {
                Id = "H3",
                Name = "UTM",
                District = "University Area",
                PricePerNight = 20,
                Floors = 4,
                Stars = 2,
                Description = "Affordable comfort for students and business travelers.",
                Amenities = new List<string> { "WiFi", "Kettle" },
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Room", PricePerNight = 20m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Room",   PricePerNight = 35m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Suite",         PricePerNight = 70m }
                }
            }
        };
    }

    public IReadOnlyList<Hotel> GetAllHotels() => _hotels;
    public Hotel? GetHotelById(string id) =>
        _hotels.FirstOrDefault(h => h.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}