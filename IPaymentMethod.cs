namespace HotelBooking.Interfaces
{
    public interface IPaymentMethod
    {
        string Name { get; }
        string GetPaymentDetails();
    }
}
