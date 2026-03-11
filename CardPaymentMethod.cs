using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public class CardPaymentMethod : IPaymentMethod
    {
        public string Name => "Card";
        public string GetPaymentDetails() => "Paid by Card";
    }
}
