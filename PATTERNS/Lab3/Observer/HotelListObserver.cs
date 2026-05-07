namespace PATTERNS.Lab3.Observer;

public class HotelListObserver : IHotelObserver
{
    public List<FilteredHotel> Hotels { get; private set; } = new();

    public void Update(List<FilteredHotel> hotels)
    {
        Hotels = hotels;
    }
}