namespace PATTERNS.Interfaces;

public interface IUiFactory
{
    IConfirmationMessage CreateConfirmation(string bookingCode, string hotelName, string roomName, decimal totalPrice);
    IConfirmationMessage CreateError(string errorText);
}

// AbstractFactory///////////// 