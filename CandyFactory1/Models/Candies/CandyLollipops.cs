using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1.Models.Candies;
// Конфеты-леденцы
public class CandyLollipops : Candy
{
    // Уровень сладкости 1- максимально не сладка 5 - максимально сладкая
    private double _sweetnessLevel;
    public double SweetnessLevel
    {
        get => _sweetnessLevel;
        set
        {
            if (value < 1)
            {
                _sweetnessLevel = 1;
            }else if (value > 5)
            {
                _sweetnessLevel = 5;
            }
            else
            {
                _sweetnessLevel = value;
            }
        }
    } 
    public CandyLollipops(string name, double priceForSale, Filling filling, Glaze glaze, Wrapper wrapper, double sweetnessLevel) : base(name, priceForSale, filling, glaze, wrapper)
    {
        SweetnessLevel = sweetnessLevel;
    }

    public override string BriefInfo()
    {
        return $"Конфета леденец: {Name}, Цена: {PriceForSale}";
    }

    public override string Display()
   {
       var lollipopsToString = $"Конфета-леденец : {Name}\n" +
                           $"Цена на продажу : {PriceForSale} руб.\n" +
                           $"Cебестоимость : {CostPrice} руб.\n" +
                           $"Начинка : {_filling.FillingName}\n" +
                           $"Глазурь : {_glaze.GlazeName}\n" +
                           $"Уровень сладости : {SweetnessLevel}\n" +
                           $"Обертка : {_wrapper.WrapperName}\n";
       return lollipopsToString;
   }


}