namespace PATTERNS.Domain;

public class RoomTemplate : ICloneable
{
    public RoomType Type { get; init; }
    public string Name { get; init; } = "";
    public decimal PricePerNight { get; init; }

    // Prototype: клонирование шаблона //////////////////////
    public object Clone()
    {
        return new RoomTemplate
        {
            Type = this.Type,
            Name = this.Name,
            PricePerNight = this.PricePerNight
        };
    }
}