using System;

namespace HotelBooking.Domain
{
    public class Booking
    {
        public string ConfirmationNumber { get; set; } = string.Empty;
        public Hotel Hotel { get; set; } = null!;
        public RoomTemplate Room { get; set; } = null!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
