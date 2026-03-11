using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public class ConfirmationMessage : IConfirmationMessage
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}
