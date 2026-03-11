using System;
using System.Collections.Generic;
using HotelBooking.Domain;

namespace HotelBooking.Models
{
    public class BookingViewModel
    {
        public int SelectedHotelId { get; set; }
        public RoomType SelectedRoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public string PaymentType { get; set; } = "Card";

        public List<Hotel> Hotels { get; set; } = new();
        public List<string> PaymentTypes { get; set; } = new() { "Card", "Cash", "Crypto" };
    }
}
