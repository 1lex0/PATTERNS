namespace PATTERNS.Domain;

public class Hotel
{
    public string Id { get; init; } = "";
    public string Name { get; init; } = "";
    public List<RoomTemplate> RoomTemplates { get; init; } = new();
}