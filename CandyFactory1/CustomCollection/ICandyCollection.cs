namespace CandyFactory1.CustomCollection;

// Интерфес нашей коллекции
public interface ICandyCollection<T> : ICollection<T>
{
    // Методы нашего интерфеса
    double SalePriceOfCandies();
    double CostPriceOfCandies();
    void SortCandies(Func<T, T, bool> compareFunc, bool upward);
}