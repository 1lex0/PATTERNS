namespace PATTERNS.Composite;

// Composite: Leaf — конечный элемент дерева (комната)
public class RoomLeaf : IHotelComponent
{
    public string Name { get; }
    public string RoomType { get; }
    public decimal PricePerNight { get; }
    public string Status { get; set; }  // "free", "occupied", "cleaning"

    public RoomLeaf(string name, string roomType, decimal pricePerNight, string status = "free")
    {
        Name = name;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        Status = status;
    }

    public decimal GetTotalPrice() => PricePerNight;
    public int GetRoomCount() => 1;

    // Считаем только свободные комнаты
    public int GetFreeRoomCount() => Status == "free" ? 1 : 0;

    public void Display(int indent = 0)
    {
        var prefix = new string(' ', indent * 2);
        var statusIcon = Status switch
        {
            "occupied" => "🔴",
            "cleaning" => "🟡",
            _ => "🟢"
        };
        Console.WriteLine($"{prefix}{statusIcon} {Name} ({RoomType}) — {PricePerNight} EUR/night [{Status}]");
    }
}