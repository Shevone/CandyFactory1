using System.Collections;
using CandyFactory1.Models.Candies;

namespace CandyFactory1.CustomCollection;

public class CandyCollection<T> : ICandyCollection<T> where T: Candy
{
    private List<T> _list = new(); // Список в котором все хранится

    public int Count => _list.Count;
    public bool IsReadOnly => false;

    // =================================================================
    // Метод который возврщает сумму для продажи всех конфет в коллекции
    public double SalePriceOfCandies()
    {
        double sum = 0;
        foreach (T candy in _list)
        {
            sum += candy.PriceForSale;
        }

        return sum;
    }
    // Метод который возвращает сбеистоимость всех конфет коллекции
    public double CostPriceOfCandies()
    {
        double sum = 0;
        foreach (T candy in _list)
        {
            sum += candy.PriceForSale;
        }
        return sum;
    }
    // метод сортировки 
    public void SortCandies(Func<T, T, bool> compareFunc, bool upward)
    {
        // простая пузырькова сортировка
        var len = Count;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                // Сравнивание элментов проиходит в переданном делегате(функции)
                bool firstBigger = compareFunc(_list[j], _list[j + 1]);
                if((upward && firstBigger) || (!upward && !firstBigger))
                {
                    (_list[j], _list[j + 1]) = (_list[j + 1], _list[j]);
                }
            }
        }
    }

    // =================================================================
    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        return _list.Remove(item);
    }
    
    // =================================================================
    public IEnumerator<T> GetEnumerator()
    {
        // метод возвращает объект для итерации
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}