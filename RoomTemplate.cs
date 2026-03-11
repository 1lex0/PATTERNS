namespace HotelBooking.Domain
{
    public class RoomTemplate
    {
        public RoomType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }

        public RoomTemplate Clone()
        {
            return new RoomTemplate
            {
                Type = this.Type,
                Description = this.Description,
                PricePerNight = this.PricePerNight
            };
        }
    }
}
