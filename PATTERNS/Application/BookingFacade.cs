using PATTERNS.Bridge;
using PATTERNS.Domain;
using PATTERNS.Interfaces;
using PATTERNS.Lab3.Command;
using PATTERNS.Lab3.Command.Commands;

namespace PATTERNS.Application;

// Facade: скрывает сложность работы с BookingService + Bridge-уведомлениями
// Контроллер вызывает один метод — фасад делает всё сам
public class BookingFacade : IBookingFacade
{
    private readonly BookingService _bookingService;
    private readonly IConfiguration _configuration;

    public BookingFacade(BookingService bookingService, IConfiguration configuration)
    {
        _bookingService = bookingService;
        _configuration = configuration;
    }

    // Facade: один метод вместо кучи вызовов в контроллере
    public (Booking? booking, IConfirmationMessage message) CreateBookingWithNotification(
    string hotelId,
    RoomType roomType,
    DateOnly checkIn,
    DateOnly checkOut,
    int guests,
    string paymentType,
    string guestName = "Guest")
    {
        // 1. Создаём бронирование (внутри: Builder, Prototype, Factory Method)
        var (booking, message) = _bookingService.CreateBooking(
    hotelId, roomType, checkIn, checkOut, guests, paymentType, guestName);

        // 2. Отправляем уведомление через Bridge
        if (booking is not null)
        {
            // Command pattern: создаём команду и выполняем через invoker
            var record = new BookingRecord
            {
                BookingCode = booking.BookingCode,
                GuestName = guestName,
                HotelName = booking.HotelName,
                RoomName = booking.RoomName,
                TotalPrice = booking.TotalPrice,
                CreatedAt = DateTime.Now
            };
            var createCommand = new CreateBookingCommand(BookingCommandStore.Storage, record);
            BookingCommandStore.Invoker.ExecuteCommand(createCommand);

            SendConfirmationNotifications(booking);
        }
        else
        {
            // Ошибка → только Web-консоль
            SendErrorNotification(message.Body);
        }

        return (booking, message);
    }

    private void SendConfirmationNotifications(Booking booking)
    {
        var fromEmail = _configuration["MailSettings:FromEmail"] ?? "";
        var appPassword = _configuration["MailSettings:AppPassword"] ?? "";

        // Bridge: Web-канал (консоль) — быстро, синхронно
        var webSender = new WebNotificationSender();
        var webNotification = new BookingConfirmationNotification(
            webSender,
            booking.BookingCode,
            booking.HotelName,
            booking.RoomName,
            booking.TotalPrice);
        webNotification.Notify(fromEmail);

        // Bridge: SMTP-канал — отправляем в фоне, не блокируем пользователя
        Task.Run(() =>
        {
            try
            {
                var smtpSender = new SmtpNotificationSender(fromEmail, appPassword);
                var smtpNotification = new BookingConfirmationNotification(
                    smtpSender,
                    booking.BookingCode,
                    booking.HotelName,
                    booking.RoomName,
                    booking.TotalPrice);
                smtpNotification.Notify(fromEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BACKGROUND SMTP ERROR] {ex.Message}");
            }
        });
    }

    private void SendErrorNotification(string errorMessage)
    {
        var webSender = new WebNotificationSender();
        var errorNotification = new BookingErrorNotification(webSender, errorMessage);
        errorNotification.Notify("system");
    }
}