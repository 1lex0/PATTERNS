namespace HotelBooking.Domain
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<RoomTemplate> RoomTemplates { get; set; } = new();
    }
}
