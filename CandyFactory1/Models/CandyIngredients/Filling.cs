namespace CandyFactory1.Models.CandyIngredients;

// Начинка
public class Filling
{
    public Filling(string fillingName, double price)
    {
        Price = price;
        FillingName = fillingName;
    }
    public string FillingName { get; } // Поле которое содержит название начинки
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
        return "Начинка : " + FillingName + "\nЦена добавления в одну конфету : " + Price;
    }
}