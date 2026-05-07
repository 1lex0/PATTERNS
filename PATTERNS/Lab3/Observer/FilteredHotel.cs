namespace PATTERNS.Lab3.Observer;

public class FilteredHotel
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string District { get; set; } = "";
    public double PricePerNight { get; set; }
    public int Floors { get; set; }
    public int Stars { get; set; }
    public string Description { get; set; } = "";
    public List<string> Amenities { get; set; } = new();
}