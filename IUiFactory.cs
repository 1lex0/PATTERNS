namespace HotelBooking.Interfaces
{
    public interface IUiFactory
    {
        IConfirmationMessage CreateSuccessMessage(string confirmationNumber, decimal totalPrice);
        IConfirmationMessage CreateErrorMessage(string error);
    }
}
