using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1.Models.Candies;

public abstract class Candy
{
    public string Name { get; } 
    protected Filling _filling;
    protected Glaze _glaze;
    protected Wrapper _wrapper;
    public double CostPrice => _filling.Price + _glaze.Price + _wrapper.Price; // Cебестоимость конфеты
    private double _priceForSale; // Поле, в котором хранится стоимость конфеты на продажу
    public double PriceForSale // Свойство, через которое устанавливаю и получаю
    {
        get => _priceForSale;
        set
        {
            if (value <= 0)
            {
                _priceForSale = 0.1;
                return;
            }
            _priceForSale = value;
        }
    }
    protected Candy(string name, double priceForSale,Filling filling, Glaze glaze, Wrapper wrapper)
    {
        _filling = filling;
        _glaze = glaze;
        _wrapper = wrapper;
        Name = name;
        PriceForSale = priceForSale;
    }

    public virtual string BriefInfo()
    {
        // виртуальный метод для выода краткой ифнормации
        return $"Конфета {Name}";
    } 
    // виртуальный метод для вывода подробной информации о конфете
    public virtual string Display()
    {
        return $"Конфета {Name}\n" +
               $"Цена {PriceForSale}\n" +
               $"Себестоимость {CostPrice}\n" +
               $"Начинка {_filling}\n" +
               $"Глазурь {_glaze}\n" +
               $"Фантик {_wrapper}";
    } 
    public override string ToString()
    {
        return $"Конфета: {Name}, Рыночная цена: {PriceForSale}, Себестоимость {CostPrice}";
    }
    // Статический метод который сравнивает элементы по названию
    // Статический метод не требует объект класса
    // Метод compare возвразает 3 результата
    // -1 - первый меньше второ
    // 0 равны
    // 1 - первый больше второго
    // upward - флаг того, сравниваем по возрастанию или убыванию
    // метод для сравнения по имени
    public static bool OrderByName(Candy obj1, Candy obj2)
    {
        int compareRes = string.Compare(obj1.Name, obj2.Name, StringComparison.Ordinal);
        return compareRes > 0;
    }
    // метод для сравнения по себестоимост
    public static bool OrderByCostPrice(Candy obj1, Candy obj2)
    {
        int compareRes = obj1.CostPrice.CompareTo(obj2.CostPrice);
        return compareRes > 0;
    }
    // метод для сравнения по рыночной цене
    public static bool OrderBySalePrice(Candy obj1, Candy obj2)
    {
        int compareRes = obj1.PriceForSale.CompareTo(obj2.PriceForSale);
        return compareRes > 0;
    }
}