using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public class WebUiFactory : IUiFactory
    {
        public IConfirmationMessage CreateSuccessMessage(string confirmationNumber, decimal totalPrice)
        {
            return new ConfirmationMessage
            {
                Message = $"Booking confirmed! Number: {confirmationNumber}. Total: {totalPrice:C}",
                IsSuccess = true
            };
        }

        public IConfirmationMessage CreateErrorMessage(string error)
        {
            return new ConfirmationMessage
            {
                Message = $"Error: {error}",
                IsSuccess = false
            };
        }
    }
}
