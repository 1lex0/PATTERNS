using HotelBooking.Interfaces;

namespace HotelBooking.Application
{
    public static class PaymentMethodFactory
    {
        public static IPaymentMethod Create(string type)
        {
            return type switch
            {
                "Card" => new CardPaymentMethod(),
                "Cash" => new CashPaymentMethod(),
                "Crypto" => new CryptoPaymentMethod(),
                _ => new CashPaymentMethod()
            };
        }
    }
}
