using PATTERNS.Interfaces;

namespace PATTERNS.Application;

// AbstractFactory /////////

public class WebUiFactory : IUiFactory
{
    public IConfirmationMessage CreateConfirmation(string bookingCode, string hotelName, string roomName, decimal totalPrice)
    {
        var title = "Booking Confirmed";
        var body = $"Code: {bookingCode}\nHotel: {hotelName}\nRoom: {roomName}\nTotal: {totalPrice} EUR";
        return new ConfirmationMessage(title, body);
    }

    public IConfirmationMessage CreateError(string errorText)
    {
        return new ConfirmationMessage("Error", errorText);
    }
}