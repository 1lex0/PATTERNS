namespace PATTERNS.Lab3.Observer;

public interface IHotelSubject
{
    void Subscribe(IHotelObserver observer);
    void Unsubscribe(IHotelObserver observer);
    void Notify();
}