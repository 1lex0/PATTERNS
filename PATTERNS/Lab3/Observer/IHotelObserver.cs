namespace PATTERNS.Lab3.Observer;

public interface IHotelObserver
{
    void Update(List<FilteredHotel> hotels);
}