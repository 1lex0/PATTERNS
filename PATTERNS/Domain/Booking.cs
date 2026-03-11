namespace PATTERNS.Domain;

public class Booking
{
    public string BookingCode { get; set; } = "";
    public string HotelId { get; set; } = "";
    public string HotelName { get; set; } = "";

    public RoomType RoomType { get; set; }
    public string RoomName { get; set; } = "";

    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public int Guests { get; set; }

    public string PaymentMethodName { get; set; } = "";
    public decimal TotalPrice { get; set; }
}