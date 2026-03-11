using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public class CashPaymentMethod : IPaymentMethod
    {
        public string Name => "Cash";
        public string GetPaymentDetails() => "Paid by Cash";
    }
}
