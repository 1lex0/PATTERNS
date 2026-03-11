using HotelBooking.Domain;
using HotelBooking.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.Infrastructure
{
    public class InMemoryHotelRepository : IHotelRepository
    {
        private static readonly InMemoryHotelRepository _instance = new();
        public static InMemoryHotelRepository Instance => _instance;

        private readonly List<Hotel> _hotels;

        private InMemoryHotelRepository()
        {
            _hotels = new List<Hotel>
            {
                new Hotel
                {
                    Id = 1,
                    Name = "Grand Plaza",
                    Address = "123 Main St",
                    RoomTemplates = new List<RoomTemplate>
                    {
                        new RoomTemplate { Type = RoomType.Standard, Description = "Standard Room", PricePerNight = 100 },
                        new RoomTemplate { Type = RoomType.Deluxe, Description = "Deluxe Room", PricePerNight = 150 },
                        new RoomTemplate { Type = RoomType.Suite, Description = "Suite Room", PricePerNight = 250 }
                    }
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Ocean View",
                    Address = "456 Beach Ave",
                    RoomTemplates = new List<RoomTemplate>
                    {
                        new RoomTemplate { Type = RoomType.Standard, Description = "Standard Room", PricePerNight = 120 },
                        new RoomTemplate { Type = RoomType.Deluxe, Description = "Deluxe Room", PricePerNight = 180 },
                        new RoomTemplate { Type = RoomType.Suite, Description = "Suite Room", PricePerNight = 300 }
                    }
                }
            };
        }

        public IEnumerable<Hotel> GetHotels() => _hotels;

        public Hotel? GetHotelById(int id) => _hotels.FirstOrDefault(h => h.Id == id);

        public RoomTemplate? GetRoomTemplate(int hotelId, RoomType type)
        {
            var hotel = GetHotelById(hotelId);
            return hotel?.RoomTemplates.FirstOrDefault(r => r.Type == type);
        }
    }
}
