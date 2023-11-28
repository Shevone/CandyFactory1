namespace CandyFactory1.Models.CandyIngredients;
// Фантик
public class Wrapper
{
    public Wrapper(string wrapperName, double price)
    {
        Price = price;
        WrapperName = wrapperName;
    }
    public string WrapperName { get; } // Поле которое содержит название начинки
    private double _price; // Поле которое содержит цену
    public double Price // Свойство, через которое устанавливается значенеи цены
    {
        get => _price;
        set
        {
            // Проверяем чтоб цена которую передают не была меньше 0
            if (value < 0)
            {
                _price = 0.1;
                return;
            }
            _price = value;
        }
    }
    public override string ToString()
    {
        return "Фантик : " + WrapperName + "\nЦена одной обертки : " + Price;
    }
}