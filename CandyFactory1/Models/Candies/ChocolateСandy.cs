using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1.Models.Candies;

public class ChocolateСandy : Candy
{
    private double _nutritionalValue; // Пищевая ценность одной шоколадной конфеты в граммах
    public double NutritionalValue
    {
        get => _nutritionalValue;
        // Утсанавливаем (не может быть меньше 0 и больше 20)
        set
        {
            if (value <= 0)
            {
                _nutritionalValue = 0.1;
            }
            else if (value > 20)
            {
                _nutritionalValue = 20;
            }
            else
            {
                _nutritionalValue = value;
            }
        }
    }
    public ChocolateСandy(string name, double priceForSale, Filling filling, Glaze glaze, Wrapper wrapper, double nutritionalValue) : base(name, priceForSale, filling, glaze, wrapper)
    {
        NutritionalValue = nutritionalValue;
    }

    public override string BriefInfo()
    {
        return $"Шоколадная конфета: {Name}, Цена: {PriceForSale}";
    }

    public override string Display()
    {
        var chocoToString = $"Шоколадная конфета : {Name}\n" +
                                $"Цена на продажу : {PriceForSale} руб.\n" +
                                $"Cебестоимость : {CostPrice} руб.\n" +
                                $"Начинка : {_filling.FillingName}\n" +
                                $"Глазурь : {_glaze.GlazeName}\n" +
                                $"Пищевая ценность : {NutritionalValue}гр.\n" +
                                $"Обертка : {_wrapper.WrapperName}";
        return chocoToString;
    }
}