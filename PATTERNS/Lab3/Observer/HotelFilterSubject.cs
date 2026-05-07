using PATTERNS.Interfaces;

namespace PATTERNS.Lab3.Observer;

public class HotelFilterSubject : IHotelSubject
{
    private readonly List<IHotelObserver> _observers = new();
    private readonly IHotelRepository _repository;

    public string District { get; set; } = "";
    public double MaxPrice { get; set; } = 9999;
    public int MinStars { get; set; } = 0;
    public List<string> RequiredAmenities { get; set; } = new();

    public HotelFilterSubject(IHotelRepository repository)
    {
        _repository = repository;
    }

    public void Subscribe(IHotelObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IHotelObserver observer) => _observers.Remove(observer);

    public void Notify()
    {
        var result = _repository.GetAllHotels()
            .Where(h => string.IsNullOrEmpty(District) || h.District == District)
            .Where(h => h.PricePerNight <= MaxPrice)
            .Where(h => h.Stars >= MinStars)
            .Where(h => !RequiredAmenities.Any() ||
                        RequiredAmenities.All(a => h.Amenities.Contains(a)))
            .Select(h => new FilteredHotel
            {
                Id = h.Id,
                Name = h.Name,
                District = h.District,
                PricePerNight = h.PricePerNight,
                Floors = h.Floors,
                Stars = h.Stars,
                Description = h.Description,
                Amenities = h.Amenities
            })
            .ToList();

        foreach (var observer in _observers)
            observer.Update(result);
    }
}