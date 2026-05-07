namespace PATTERNS.Domain;

public class Hotel
{
    public string Id { get; init; } = "";
    public string Name { get; init; } = "";
    public List<RoomTemplate> RoomTemplates { get; init; } = new();

    // Новые поля для Observer (фильтры)
    public string District { get; init; } = "";
    public double PricePerNight { get; init; }
    public int Floors { get; init; }
    public List<string> Amenities { get; init; } = new();
    public string Description { get; init; } = "";
    public int Stars { get; init; }
}