using PATTERNS.Domain;
using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// Интерфейс нужен чтобы Proxy и BookingFacade реализовали одинаковый контракт
public interface IBookingFacade
{
    (Booking? booking, IConfirmationMessage message) CreateBookingWithNotification(
        string hotelId,
        RoomType roomType,
        DateOnly checkIn,
        DateOnly checkOut,
        int guests,
        string paymentType,
        string guestName = "Guest");
}