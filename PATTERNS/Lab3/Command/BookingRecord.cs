namespace PATTERNS.Lab3.Command;

public class BookingRecord
{
    public string BookingCode { get; set; } = "";
    public string GuestName { get; set; } = "";
    public string HotelName { get; set; } = "";
    public string RoomName { get; set; } = "";
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsCancelled { get; set; } = false;
}