using System.Text;
using CandyFactory1.Models.Candies;

namespace CandyFactory1.Models;

// Класс - коробка конфет
public class CandyBox
{
    private string Name; // Название
    private Dictionary<Candy, int> _candies = new(); // Конфеты будут хранится в словаре
    // Ключ - конфета, значение - количесвто

    public CandyBox(string name, List<Candy> candies)
    {
        //в конструкторе записываем по одной конфеткке переденной
        Name = name;
        foreach (Candy candy in candies)
        {
            AddCandy(candy,1);
        }
    }
    // Добавляем конфету в коробку в указанном количестве
    public void AddCandy(Candy candy, int count)
    {
        if (!_candies.ContainsKey(candy))
        {
            _candies.Add(candy,0);
        }
        _candies[candy] += count;
    }

    // Определям то как выглядит в консоли
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Коробка конфет : {Name}\n");
        foreach (Candy candy in _candies.Keys)
        {
            sb.Append($"- {candy} | кол-во {_candies[candy]}\n");
        }
        return sb.ToString();
    }
}