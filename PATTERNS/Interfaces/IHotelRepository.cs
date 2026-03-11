using PATTERNS.Domain;

namespace PATTERNS.Interfaces;

public interface IHotelRepository
{
    IReadOnlyList<Hotel> GetAllHotels();
    Hotel? GetHotelById(string id);
}