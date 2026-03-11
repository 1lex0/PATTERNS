using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public class CryptoPaymentMethod : IPaymentMethod
    {
        public string Name => "Crypto";
        public string GetPaymentDetails() => "Paid by Crypto";
    }
}
