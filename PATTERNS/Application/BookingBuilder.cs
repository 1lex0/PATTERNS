using PATTERNS.Domain;

namespace PATTERNS.Application;

// Builder //////////

public class BookingBuilder
{
    private readonly Booking _booking = new();

    public BookingBuilder SetHotel(string hotelId, string hotelName)
    {
        _booking.HotelId = hotelId;
        _booking.HotelName = hotelName;
        return this;
    }

    public BookingBuilder SetRoom(RoomType roomType, string roomName)
    {
        _booking.RoomType = roomType;
        _booking.RoomName = roomName;
        return this;
    }


    public BookingBuilder SetDates(DateOnly checkIn, DateOnly checkOut)
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

    public BookingBuilder SetPayment(string paymentName)
    {
        _booking.PaymentMethodName = paymentName;
        return this;
    }

    public BookingBuilder SetTotalPrice(decimal total)
    {
        _booking.TotalPrice = total;
        return this;
    }

    public BookingBuilder SetBookingCode(string code)
    {
        _booking.BookingCode = code;
        return this;
    }

    public Booking Build() => _booking;
}