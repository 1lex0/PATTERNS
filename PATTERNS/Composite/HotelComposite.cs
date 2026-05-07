namespace PATTERNS.Composite;

// Composite: Composite (корень) — отель содержит этажи
public class HotelComposite : IHotelComponent
{
    public string Name { get; }
    private readonly List<IHotelComponent> _floors = new();

    public HotelComposite(string name)
    {
        Name = name;
    }

    public void Add(IHotelComponent component)
    {
        _floors.Add(component);
    }

    public void Remove(IHotelComponent component)
    {
        _floors.Remove(component);
    }

    public IReadOnlyList<IHotelComponent> GetChildren() => _floors;

    public decimal GetTotalPrice() => _floors.Sum(f => f.GetTotalPrice());
    public int GetRoomCount() => _floors.Sum(f => f.GetRoomCount());

    // Composite: суммируем свободные по всем этажам
    public int GetFreeRoomCount() => _floors.OfType<FloorComposite>().Sum(f => f.GetFreeRoomCount());

    public void Display(int indent = 0)
    {
        var prefix = new string(' ', indent * 2);
        Console.WriteLine($"{prefix}🏨 {Name} — {GetRoomCount()} rooms, Free: {GetFreeRoomCount()}");
        foreach (var floor in _floors)
        {
            floor.Display(indent + 1);
        }
    }
}