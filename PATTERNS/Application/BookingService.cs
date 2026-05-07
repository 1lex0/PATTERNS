using PATTERNS.Domain;
using PATTERNS.Interfaces;
using PATTERNS.Lab3.State;

namespace PATTERNS.Application;

public class BookingService
{
    private readonly IHotelRepository _repo;
    private readonly PaymentMethodFactory _paymentFactory;
    private readonly IUiFactory _uiFactory;

    public BookingService(IHotelRepository repo, PaymentMethodFactory paymentFactory, IUiFactory uiFactory)
    {
        _repo = repo;
        _paymentFactory = paymentFactory;
        _uiFactory = uiFactory;
    }

    public (Booking? booking, IConfirmationMessage message) CreateBooking(
    string hotelId,
    RoomType roomType,
    DateOnly checkIn,
    DateOnly checkOut,
    int guests,
    string paymentType,
    string guestName = "Guest")   // <- добавь это
    {
        if (checkOut <= checkIn)
            return (null, _uiFactory.CreateError("Check-out must be after check-in."));

        if (guests <= 0)
            return (null, _uiFactory.CreateError("Guests must be at least 1."));

        var hotel = _repo.GetHotelById(hotelId);
        if (hotel is null)
            return (null, _uiFactory.CreateError("Hotel not found."));

        var template = hotel.RoomTemplates.FirstOrDefault(t => t.Type == roomType);
        if (template is null)
            return (null, _uiFactory.CreateError("Room type not available in this hotel."));

        // Prototype: клонируем шаблон комнаты
        var room = (RoomTemplate)template.Clone();

        var nights = (checkOut.DayNumber - checkIn.DayNumber);
        var total = room.PricePerNight * nights;

        // Factory Method: создаём способ оплаты (через интерфейс IPaymentMethod)
        IPaymentMethod payment = _paymentFactory.Create(paymentType);
        var paid = payment.Pay(total);
        if (!paid)
            return (null, _uiFactory.CreateError("Payment failed."));

        // Builder: собираем Booking пошагово
        var bookingCode = $"BK-{DateTime.UtcNow:yyyyMMddHHmmss}-{Random.Shared.Next(100, 999)}";

        var booking = new BookingBuilder()
            .SetHotel(hotel.Id, hotel.Name)
            .SetRoom(room.Type, room.Name)
            .SetDates(checkIn, checkOut)
            .SetGuests(guests)
            .SetPayment(payment.Name)
            .SetTotalPrice(total)
            .SetBookingCode(bookingCode)
            .Build();

        // Abstract Factory: создаём объект UI-сообщения
        var msg = _uiFactory.CreateConfirmation(booking.BookingCode, booking.HotelName, booking.RoomName, booking.TotalPrice);

        // State pattern: добавляем бронирование в StateStore
        BookingStateStore.Add(new BookingContext
        {
            BookingId = booking.BookingCode,
            GuestName = guestName,
            HotelName = booking.HotelName,
            RoomType = booking.RoomName,
            CheckIn = checkIn.ToDateTime(TimeOnly.MinValue),
            CheckOut = checkOut.ToDateTime(TimeOnly.MinValue),
            TotalPrice = (double)booking.TotalPrice,
            State = new PendingState()
        });

        return (booking, msg);
    }
}