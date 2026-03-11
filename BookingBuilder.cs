using HotelBooking.Domain;

namespace HotelBooking.Application
{
    public class BookingBuilder
    {
        private readonly Booking _booking = new();

        public BookingBuilder SetHotel(Hotel hotel)
        {
            _booking.Hotel = hotel;
            return this;
        }

        public BookingBuilder SetRoom(RoomTemplate room)
        {
            _booking.Room = room;
            return this;
        }

        public BookingBuilder SetDates(DateTime checkIn, DateTime checkOut)
        {
            _booking.CheckIn = checkIn;
            _booking.CheckOut = checkOut;
            return this;
        }

        public BookingBuilder SetGuests(int guests)
        {
            _booking.Guests = guests;
            return this;
        }

        public BookingBuilder SetPaymentType(string paymentType)
        {
            _booking.PaymentType = paymentType;
            return this;
        }

        public BookingBuilder CalculateTotalPrice()
        {
            var nights = (_booking.CheckOut - _booking.CheckIn).Days;
            _booking.TotalPrice = nights * _booking.Room.PricePerNight;
            return this;
        }

        public BookingBuilder GenerateConfirmationNumber()
        {
            _booking.ConfirmationNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            return this;
        }

        public Booking Build()
        {
            return _booking;
        }
    }
}
