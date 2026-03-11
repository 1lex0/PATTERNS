namespace HotelBooking.Interfaces
{
    public interface IConfirmationMessage
    {
        string Message { get; }
        bool IsSuccess { get; }
    }
}
