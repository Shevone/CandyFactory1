using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1.Models.Candies;
// Конфеты - желе
public class JellyCandy : Candy
{
    private string _color { get; }
    public JellyCandy(string name, double priceForSale, Filling filling, Glaze glaze, Wrapper wrapper, string color) : base(name, priceForSale, filling, glaze, wrapper)
    {
        _color = color;
    }

    public override string BriefInfo()
    {
        return $"Конфета желе: {Name}, Цена: {PriceForSale}";
    }

    public override string Display()
    {
        var jellyToString = $"Конфета-желе : {Name}\n" +
                            $"Цена на продажу : {PriceForSale} руб.\n" +
                            $"Cебестоимость : {CostPrice} руб.\n" +
                            $"Начинка : {_filling.FillingName}\n" +
                            $"Глазурь : {_glaze.GlazeName}\n" +
                            $"Цвет : {_color}\n" +
                            $"Обертка : {_wrapper.WrapperName}";
        return jellyToString;
    }
}