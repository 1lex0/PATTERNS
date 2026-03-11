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
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Room", PricePerNight = 80m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Room",   PricePerNight = 120m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Suite",        PricePerNight = 200m }
                }
            },

            new Hotel
            {
                Id = "H3",
                Name = "UTM",
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Room", PricePerNight = 20m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Room",   PricePerNight = 35m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Suite",        PricePerNight = 70m }
                }
            },


            new Hotel
            {
                Id = "H2",
                Name = "SeaMoon Resort",
                RoomTemplates = new List<RoomTemplate>
                {
                    new RoomTemplate { Type = RoomType.Standard, Name = "Standard Sea View", PricePerNight = 95m },
                    new RoomTemplate { Type = RoomType.Deluxe,   Name = "Deluxe Sea View",   PricePerNight = 145m },
                    new RoomTemplate { Type = RoomType.Suite,    Name = "Ocean Suite",       PricePerNight = 240m }
                }
            }
        };
    }

    public IReadOnlyList<Hotel> GetAllHotels() => _hotels;

    public Hotel? GetHotelById(string id) =>
        _hotels.FirstOrDefault(h => h.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}