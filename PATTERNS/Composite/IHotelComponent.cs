namespace PATTERNS.Composite;

// Composite: общий интерфейс для листьев (Room) и контейнеров (Floor, Hotel)
// Клиентский код работает одинаково с любым компонентом
public interface IHotelComponent
{
    string Name { get; }
    decimal GetTotalPrice();   // цена за 1 ночь: для комнаты — своя, для этажа/отеля — сумма дочерних
    int GetRoomCount();        // кол-во комнат: для комнаты — 1, для этажа/отеля — сумма дочерних
    void Display(int indent = 0); // вывод дерева в консоль с отступами
}