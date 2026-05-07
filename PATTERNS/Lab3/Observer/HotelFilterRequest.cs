namespace PATTERNS.Lab3.Observer;

public class HotelFilterRequest
{
    public string? District { get; set; }
    public double MaxPrice { get; set; }
    public int MinStars { get; set; }
    public List<string>? Amenities { get; set; }
}   