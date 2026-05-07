namespace PATTERNS.Lab3.Strategy;

public class PricingRequest
{
    public string HotelId { get; set; } = "";
    public string RoomType { get; set; } = "";
    public int Nights { get; set; }
    public int Guests { get; set; }
    public string Strategy { get; set; } = "base";
}