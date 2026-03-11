using HotelBooking.Domain;
using HotelBooking.Interfaces;
using System;

namespace HotelBooking.Application
{
    public class BookingService
    {
        private readonly IHotelRepository _hotelRepository;

        public BookingService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Booking? CreateBooking(int hotelId, RoomType roomType, DateTime checkIn, DateTime checkOut, int guests, string paymentType)
        {
            var hotel = _hotelRepository.GetHotelById(hotelId);
            if (hotel == null) return null;

            var roomTemplate = _hotelRepository.GetRoomTemplate(hotelId, roomType)?.Clone();
            if (roomTemplate == null) return null;

            var builder = new BookingBuilder()
                .SetHotel(hotel)
                .SetRoom(roomTemplate)
                .SetDates(checkIn, checkOut)
                .SetGuests(guests)
                .SetPaymentType(paymentType)
                .CalculateTotalPrice()
                .GenerateConfirmationNumber();

            return builder.Build();
        }
    }
}
