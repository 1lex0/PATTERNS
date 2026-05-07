using PATTERNS.Application;
using PATTERNS.Domain;
using PATTERNS.Interfaces;

namespace PATTERNS.Infrastructure;

// Proxy (Logging): обёртка над BookingFacade
// Логирует каждое бронирование в файл — это аудит для бизнеса
public class LoggingBookingServiceProxy : IBookingFacade
{
    private readonly BookingFacade _realFacade;
    private readonly string _logFilePath;
    private static readonly object _lock = new(); // защита от одновременной записи

    public LoggingBookingServiceProxy(BookingFacade realFacade, IWebHostEnvironment env)
    {
        _realFacade = realFacade;

        // Папка Logs/ в корне проекта
        var logsDir = Path.Combine(env.ContentRootPath, "Logs");
        Directory.CreateDirectory(logsDir); // создаст если нет

        _logFilePath = Path.Combine(logsDir, "bookings.log");
    }

    public (Booking? booking, IConfirmationMessage message) CreateBookingWithNotification(
        string hotelId,
        RoomType roomType,
        DateOnly checkIn,
        DateOnly checkOut,
        int guests,
        string paymentType,
        string guestName = "Guest")
    {
        // === ДО вызова реального фасада: логируем попытку ===
        var attemptLog = $"ATTEMPT | Hotel={hotelId} | Room={roomType} | Guests={guests} | " +
                  $"Dates={checkIn:dd.MM.yyyy}→{checkOut:dd.MM.yyyy} | Payment={paymentType} | Guest={guestName}";
        WriteLog(attemptLog);

        // === Передаём вызов реальному фасаду ===
        var (booking, message) = _realFacade.CreateBookingWithNotification(
            hotelId, roomType, checkIn, checkOut, guests, paymentType, guestName);

        // === ПОСЛЕ вызова: логируем результат ===
        if (booking is not null)
        {
            var successLog = $"SUCCESS | Code={booking.BookingCode} | Hotel={booking.HotelName} | " +
                             $"Room={booking.RoomName} | Total={booking.TotalPrice} EUR";
            WriteLog(successLog);
        }
        else
        {
            var failLog = $"FAILED  | Reason={message.Body}";
            WriteLog(failLog);
        }

        return (booking, message);
    }

    private void WriteLog(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var line = $"[{timestamp}] {message}";

        // lock нужен чтобы если несколько пользователей бронируют одновременно
        // запись в файл не ломалась
        lock (_lock)
        {
            File.AppendAllText(_logFilePath, line + Environment.NewLine);
        }

        // Дублируем в консоль Output для отладки
        Console.WriteLine($"[LOG PROXY] {line}");
    }
}