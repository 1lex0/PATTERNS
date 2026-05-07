namespace PATTERNS.Composite;

// Composite: Composite — контейнер (этаж содержит комнаты)
public class FloorComposite : IHotelComponent
{
    public string Name { get; }
    private readonly List<IHotelComponent> _children = new();

    public FloorComposite(string name)
    {
        Name = name;
    }

    public void Add(IHotelComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IHotelComponent component)
    {
        _children.Remove(component);
    }

    public IReadOnlyList<IHotelComponent> GetChildren() => _children;

    public decimal GetTotalPrice() => _children.Sum(c => c.GetTotalPrice());
    public int GetRoomCount() => _children.Sum(c => c.GetRoomCount());

    // Composite: суммируем свободные комнаты рекурсивно
    public int GetFreeRoomCount() => _children.OfType<RoomLeaf>().Sum(r => r.GetFreeRoomCount());

    public void Display(int indent = 0)
    {
        var prefix = new string(' ', indent * 2);
        Console.WriteLine($"{prefix}📂 {Name} — {GetRoomCount()} rooms, Free: {GetFreeRoomCount()}");
        foreach (var child in _children)
        {
            child.Display(indent + 1);
        }
    }
}