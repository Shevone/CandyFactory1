using System.Text;
using CandyFactory1.CustomCollection;
using CandyFactory1.Models.Candies;
using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1.Models;

public class CandyFactory
{
    private List<CandyBox> _candyBoxes; // Список производимых коробок конфет
    public List<CandyBox> CandyBoxes => (_candyBoxes);

    // ===============================
    private List<Filling> _fillings; // Список начинок
    public List<Filling> Fillings => new(_fillings); // Свойство чтоб вернуть копию всех начинок
    private List<Glaze> _glazes; // Список глазури доступной на фабрике
    public List<Glaze> Glazes => new(_glazes); // Свойство чтоб вернуть копию всех глазуре
    private List<Wrapper> _wrappers; // Cписок оберток доступных на фабрике
    public List<Wrapper> Wrappers => new(_wrappers); // Свойство чтоб вернуть копию всех оберток
    
    // =============================
    // Кастомные коллекции которые содержат конфеты разных типово производимых на фабрике
    private ICandyCollection<CandyLollipops> _candyLollipops;
    private ICandyCollection<ChocolateСandy> _chocolateСandies;
    private ICandyCollection<JellyCandy> _jellyCandies;
    
    // Продажная стоимоть всех конфет(свойство)
    public double CandysPriceSale => _candyLollipops.SalePriceOfCandies() + _chocolateСandies.SalePriceOfCandies() + _jellyCandies.SalePriceOfCandies();
    // Свойство Суммуарная себистоимость всех конфет
    public double CostPriceCandys => _candyLollipops.CostPriceOfCandies() + _chocolateСandies.CostPriceOfCandies() + _jellyCandies.CostPriceOfCandies();
    // Cвойство - список всех конфет
    public List<Candy> Candies
    {
        get
        {
            List<Candy> candies = new List<Candy>();
            foreach (CandyLollipops item in _candyLollipops)
            {
                candies.Add(item);
            }
            foreach (ChocolateСandy item in _chocolateСandies)
            {
                candies.Add(item);
            }
            foreach (JellyCandy item in _jellyCandies)
            {
                candies.Add(item);
            }
            return candies;
        }
    }

    public string CandiesString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("============================\nЛеденцы\n\n");
        foreach (CandyLollipops item in _candyLollipops)
        {
            stringBuilder.Append(item+"\n");
        }
        stringBuilder.Append("\n============================\nШоколадные\n\n");
        foreach (ChocolateСandy item in _chocolateСandies)
        {
            stringBuilder.Append(item+"\n");
        }
        stringBuilder.Append("\n============================\nЖеле\n\n");
        foreach (JellyCandy item in _jellyCandies)
        {
            stringBuilder.Append(item+"\n");
        }

        return stringBuilder.ToString();
    }
    // =============================
    // конструтнор
    public CandyFactory()
    {
        // Объявляем переменные 
        _candyBoxes = new List<CandyBox>();
        _fillings = new List<Filling>();
        _glazes = new List<Glaze>();
        _wrappers = new List<Wrapper>();
        _candyLollipops = new CandyCollection<CandyLollipops>();
        _chocolateСandies = new CandyCollection<ChocolateСandy>();
        _jellyCandies = new CandyCollection<JellyCandy>();
    }
    // Метод добавления конфеты в нашу фабрику
    public string AddCandy(Candy newCandy)
    {
        switch (newCandy)
        {
            case CandyLollipops candyLollipops:
                _candyLollipops.Add(candyLollipops);
                break;
            case ChocolateСandy chocolateСandy :
                _chocolateСandies.Add(chocolateСandy);
                break;
            case JellyCandy jellyCandy:
                _jellyCandies.Add(jellyCandy);
                break;
        }
        return newCandy.Display();
    }
    // =============================================
    // Методы добавления составления начиное
    public void AddGlaze(Glaze glaze)
    {
        _glazes.Add(glaze);
    }
    public void AddFillinng(Filling filling)
    {
        _fillings.Add(filling);
    }
    public void AddWrapper(Wrapper wrapper)
    {
        _wrappers.Add(wrapper);
    }
    public void AddCandyBox(CandyBox candyBox)
    {
        _candyBoxes.Add(candyBox);
    }
    // =============================================
    // Методы вызова сортировки
    public void InvokeSort(int index, bool upward)
    {
        // переменная которая будет содержать в себе метод сортировки
        Func<Candy, Candy, bool> compareFunc;
        // в завсимости от того, что выбрали будем выбирать метод сортировки
        switch (index)
        {
            case 1:
                // Сортирока по названи.
                compareFunc = Candy.OrderByName;
                break;
            case 2 :
                // сортировка по себестоимости
                compareFunc = Candy.OrderByCostPrice;
                break;
            case 3:
                // сортировка по цене на продужа
                compareFunc = Candy.OrderBySalePrice;
                break;
            default:
                // если пришел какой то не тот индекс
                return;
        }
        // Вызываем сортриовку всех наших коллекций с тем методом, который выбрали
        _chocolateСandies.SortCandies(compareFunc, upward);
        _jellyCandies.SortCandies(compareFunc, upward);
        _candyLollipops.SortCandies(compareFunc, upward);
    }
}