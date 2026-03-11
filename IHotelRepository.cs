using HotelBooking.Domain;
using System.Collections.Generic;

namespace HotelBooking.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetHotels();
        Hotel? GetHotelById(int id);
        RoomTemplate? GetRoomTemplate(int hotelId, RoomType type);
    }
}
