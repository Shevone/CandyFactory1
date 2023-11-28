using System.Text;
using CandyFactory1.Models;
using CandyFactory1.Models.Candies;
using CandyFactory1.Models.CandyIngredients;

namespace CandyFactory1;

static class Program
{
    private static CandyFactory Factory = new CandyFactory();
    public static void Main(string[] args)
    {
        // флаг выхода из цикла проги
        Initialize();
        bool exitFlag = false;
        while (!exitFlag)
        {
            Console.Clear();
            Console.WriteLine("Введите цифру чтоб выбрать пункт меню\n" +
                              "1 - Просмотр информации\n" +
                              "2 - Созадть конфету\n" +
                              "3 - Создать коробку конфет\n" +
                              "4 - Добавить конфету в коробку\n" +
                              "5 - Сортирровка конфет по названиям\n" +
                              "6 - Сортировка конфет по себестоимости\n" +
                              "7 - Сортировка конфет по рыночной цене\n" +
                              "8 - Выход");
            string index = Console.ReadLine() ?? "";
            switch (index)
            {
                default:
                    Console.WriteLine("Не корректный ввод");
                    break;
                case "1":
                    // Просмотр информации
                    // Просмотр информации
                    Console.WriteLine("Введите цифру чтоб посмотреть ифнмормацию\n" +
                                      "1 - Конфеты\n" +
                                      "2 - Коробки\n" +
                                      "3 - Составляющие элемнты\n" +
                                      "любая клавиша - выход\n");
                    index = Console.ReadLine() ?? "";
                    DataView(index);
                    break;
                case "2" :
                    // Создание конфеты
                    Console.WriteLine("Введите цифру чтоб Выбрать тип создаваемой конфеты\n" +
                                      "1 - Шоколадная\n" +
                                      "2 - Лединец\n" +
                                      "3 - Желе\n" +
                                      "любая клавиша - выход\n");
                    index = Console.ReadLine() ?? "";
                    CandyCreate(index);
                    break;
                case "3":
                    // Создание коробки конфет
                    Console.WriteLine("Введите название для коробки конфет");
                    string name = Console.ReadLine() ?? "";
                    if (name == "")
                    {
                        Console.WriteLine("Введено не корретно");
                        break;
                    }
                    int num = 0;
                    foreach (Candy candy in Factory.Candies)
                    {
                        Console.WriteLine($"{num} | {candy.BriefInfo()}\n");
                        num++;
                    }
                    Console.WriteLine("Введите порядковый номер конфет, которые хотите базово(изначально)\nдобавить в новую корокбу\n(необходимо числа число через пробле)");
                    // Создаем список, для услуг которые выберут
                    List<Candy> candies = new List<Candy>();
                    // Считываем строку
                    string s = Console.ReadLine() ?? "0";
                    // Записываем строку в массим, разделив через пробле
                    // 1 2 3 превратится в ["1","2","3"]
                    List<string> res = s.Split(" ").ToList();
                    // проходимся по элементам пассива
                    foreach (string item in res)
                    {
                        bool parseRes = int.TryParse(item, out int result);
                        // пытаемся перевести в число( вдруг кто то ввел не число)
                        if (parseRes)
                        {
                            // Если получилось спарсить то смотрим, есть ли под таким индексом чтото, если да то добавляем
                            Candy? candy = Factory.Candies[result];
                            if(candy == null) continue;
                            // и если нашлась усулга с таким id то добавляем её в заказ
                            candies.Add(candy);
                        }
                    }

                    if (candies.Count == 0)
                    {
                        Console.WriteLine("ничего не выбрано");
                    }
                    CandyBox candyBox = new CandyBox(name, candies);
                    Factory.AddCandyBox(candyBox);
                    break;
                case "4":
                    // Добавить конфету в коробку
                    // выбираем коробку
                    int selectedBox = SelectMenu(Factory.CandyBoxes, "Выберите коробку конфет чтоб добавить конфету");
                    if(selectedBox == -1) return;
                    CandyBox box = Factory.CandyBoxes[selectedBox];

                    int selectedCandyIndex = SelectMenu(Factory.Candies, "Выберите конфету чтоб добавить");
                    if(selectedCandyIndex == -1) return;
                    Candy selectedCandy = Factory.Candies[selectedCandyIndex];

                    int count = (int)DoubleFromConsole("Введите количесвто чтоб добавить");
                    if (count <= 0) count = 1;
                    
                    box.AddCandy(selectedCandy,count);
                    break;
                case "5":
                    // сортировка по названиям
                    Console.WriteLine("Введите 1 - если хотите сортировать по убыванию");
                    string a1 = Console.ReadLine() ?? "";
                    Factory.InvokeSort(1,a1 != "1");
                    break;
                case "6":
                    // сортировка по себестоимост
                    Console.WriteLine("Введите 1 - если хотите сортировать по убыванию");
                    string a2 = Console.ReadLine() ?? "";
                    Factory.InvokeSort(2,a2 != "1");
                    break;
                case "7":
                    // сортировка по рыночной
                    Console.WriteLine("Введите 1 - если хотите сортировать по убыванию");
                    string a3 = Console.ReadLine() ?? "";
                    Factory.InvokeSort(3,a3 != "1");
                    break;
                case "8":
                    Console.WriteLine("Выход");
                    exitFlag = true;
                    break;
            }
        }
    }
    // метод который обрабатыевает элмент меню с просмотром инфы
    private static void DataView(string index)
    {
        Console.Clear();
        // Соовбщение которое будет отображать
        StringBuilder message = new StringBuilder();
        switch (index)
        {
            case "1":
                // Конфеты
                message.Append(Factory.CandiesString());
                message.Append($"\n===================================\nСуммарная стоимость всех конфет на продажу : {Factory.CandysPriceSale}\n");
                message.Append($"Суммарная себестоисть всех конфет на продажу : {Factory.CostPriceCandys}\n");
                break;
            case "2":
                // Коробки
                foreach (CandyBox candyBox in Factory.CandyBoxes)
                {
                    message.Append(candyBox.ToString() + "\n\n");
                }
                break;
            case "3":
                // Cоставные эелменты
                message.Append("Начинки\n");
                foreach (Filling filling in Factory.Fillings)
                {
                    message.Append(filling.ToString() + "\n");
                }
                message.Append("\nГлазури\n");
                foreach (Glaze glaze in Factory.Glazes)
                {
                    message.Append(glaze.ToString() + "\n");
                }
                message.Append("\nОбертки(фантики)\n");
                foreach (Wrapper wrapper in Factory.Wrappers)
                {
                    message.Append(wrapper.ToString() + "\n");
                }
                break;
            default:
                return;
        }
        Console.WriteLine(message);
        Console.ReadKey();
    }
    
    private static void CandyCreate(string index)
    {
        if(index != "1" && index != "2" && index != "3") return;
        // Получаем с консоли все данные которые нуны для создания конфеты
        Console.WriteLine("Введите название новой конфеты");
        string name = Console.ReadLine() ?? "";
        
        double price = DoubleFromConsole("Введите цену для продажи новой конфеты");
        
        // тут мы выбриаем из коллекции по  одному наполнителю для нашей конфеты
        int filId = SelectMenu(Factory.Fillings, "Выберите начинку");
        int glazeId = SelectMenu(Factory.Glazes, "Выберите глазурь");
        int wrapperId = SelectMenu(Factory.Wrappers, "Выберите фантик для обертки");
        
        
        // Проверяем что все введено корректно
        if (name == "" || price == -1 || filId == -1 || glazeId == -1 || wrapperId == -1)
        {
            Console.WriteLine("Ошибка при вводе данных");
            return;
        }
        Filling filling = Factory.Fillings[filId];
        Glaze glaze = Factory.Glazes[glazeId];
        Wrapper wrapper = Factory.Wrappers[wrapperId];
        // В зависимости от выбранного типа делаем дела
        switch (index)
        {
            case "1":
                // Создание шоколадной конфеты
                double nutritionalValue = DoubleFromConsole("Введите пищщевую ценность конфеты");
                ChocolateСandy chocolateСandy = new ChocolateСandy(name, price, filling, glaze, wrapper, nutritionalValue);
                Factory.AddCandy(chocolateСandy);
                break;
            case "2":
                // Сощдание конфеты-леденца
                double sweetnessLevel = DoubleFromConsole("Введите уровень сладости от 1 до 5\n1 - минимальная сладость\n5-максимальная сладость");
                CandyLollipops candyLollipops = new CandyLollipops(name, price, filling, glaze, wrapper, sweetnessLevel);
                Factory.AddCandy(candyLollipops);
                break;
            case "3":
                // Создание конфеты-желе
                Console.WriteLine("Введите цвет конфеты словом");
                string color = Console.ReadLine() ?? "";
                JellyCandy jellyCandy = new JellyCandy(name, price, filling, glaze, wrapper, color);
                Factory.AddCandy(jellyCandy);
                break;
            default:
                // Выход
                return;
        }
    }
    private static double DoubleFromConsole(string message)
    {
        Console.WriteLine(message);
        var strLine = Console.ReadLine() ?? "0";
        if (double.TryParse(strLine, out double result))
        {
            return result;
        }
        return -1;
    }
    // Метод который рисует селект меню и возвращает индекс выбранного элемнта
    private static int SelectMenu<T>(ICollection<T> menuItems, string mes)
    {
        // Если необъодимо получитьь индекс выбранного элемента из переданного списка
        if (menuItems.Count == 0) return -1;
        Console.Clear();
        Console.WriteLine($"\nДля выхода нажмите 'BackSpace'\n{mes}\n");
        int row = Console.CursorTop;
        int col = Console.CursorLeft;
        int index = 0;
        while (true)
        {
            DrawMenu(menuItems, row, col, index);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < menuItems.Count - 1)
                        index++;
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                        index--;
                    break;
                case ConsoleKey.Backspace:
                    
                    Thread.Sleep(100);
                    return -1;
                case ConsoleKey.Enter:
                    return index;
            }
        }
    }
    private static void DrawMenu<T>(ICollection<T> items, int row, int col, int index)
    {
        // Метод отрисовки меню
        Console.SetCursorPosition(col, row);
        int i = 0;
        foreach (T item in items)
        {
            
            if (i == index)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine(item);
            Console.ResetColor();
            i++;
        }
        Console.WriteLine();
    }

    // Метод в котором мы инициализруем данные для работы проги
    private static void Initialize()
    {
        // Создаём различные начинки и записываем в список
        var chockFilling = new Filling("Шоколадная", 0.6);
        var caramelFilling = new Filling("Карамельная", 0.7);
        var brandyFilling = new Filling("Коньяк", 2);
        var appleJelly = new Filling("Яблочное желе", 0.25);
        var whiteChock = new Filling("Белый шоколад", 1);
        var emptyFilling = new Filling("пустая", 0);
        Factory.AddFillinng(chockFilling);
        Factory.AddFillinng(caramelFilling);
        Factory.AddFillinng(brandyFilling);
        Factory.AddFillinng(appleJelly);
        Factory.AddFillinng(whiteChock);
        Factory.AddFillinng(emptyFilling);
        
        // Cоздаем различные глазуи
        var сhockGlaze = new Glaze("Шоколадная", 0.8);
        var caramelGlaze = new Glaze("Карамельная", 1);
        var whiteChockGlaze = new Glaze("Белый шоколад",1.2);
        var appleGlaze = new Glaze("Яблочная", 0.4);
        var bananGlaze = new Glaze("Банановая", 0.5);
        Factory.AddGlaze(whiteChockGlaze);
        Factory.AddGlaze(сhockGlaze);
        Factory.AddGlaze(caramelGlaze);
        Factory.AddGlaze(appleGlaze);
        Factory.AddGlaze(bananGlaze);

        // Cоздаем разлиные упаковки(обертки, фантики)
        var wrap1 = new Wrapper("Упаковка прэмиум", 2);
        var wrap2 = new Wrapper("Упаковка обычная", 1);
        Factory.AddWrapper(wrap1);
        Factory.AddWrapper(wrap2);
        
        // Создаём шоколадные конфеты
        var chockCandy1 = new ChocolateСandy("Коровка",3.75,chockFilling,сhockGlaze,wrap2,15);
        var chockCandy2 = new ChocolateСandy("Белочка",2.75,emptyFilling,сhockGlaze,wrap2,15);
        Factory.AddCandy(chockCandy1);
        Factory.AddCandy(chockCandy2);
        
        // Создём конфеты-леденцы
        var lolCandy1 = new CandyLollipops("леденец",2,chockFilling,сhockGlaze,wrap2,2);
        var lolCandy2 = new CandyLollipops("Суперсладкий-леденец",6,appleJelly,caramelGlaze,wrap1,5);
        Factory.AddCandy(lolCandy1);
        Factory.AddCandy(lolCandy2);
        
        // Создаем конфеты-желе
        var jelCandy1 = new JellyCandy("желе яблоко",4.1,chockFilling,сhockGlaze,wrap1,"Зеленый");
        var jelCandy2 = new JellyCandy("желе бана",4.1,emptyFilling,сhockGlaze,wrap2,"Желтый");
        Factory.AddCandy(jelCandy1);
        Factory.AddCandy(jelCandy2);  
        
        // Создаем разные коробки
        var candyBox1 = new CandyBox("Коробка конфет для сластен", new List<Candy>(){chockCandy1, jelCandy1});
        var candyBox2 = new CandyBox("Шоколадная река..", new List<Candy>(){chockCandy1, chockCandy2});
        var candyBox3 = new CandyBox("Вкусно ",new List<Candy>(){lolCandy1, lolCandy1});
        Factory.AddCandyBox(candyBox1);
        Factory.AddCandyBox(candyBox2);
        Factory.AddCandyBox(candyBox3);
        candyBox2.AddCandy(chockCandy1, 10);
        candyBox2.AddCandy(chockCandy2,10);
    }

    public static void CovDemo()
    {
        //Мы создаем класс шокошладной коллекции шокол конфеты
        // под типом интерфейса ChocolateСandy
        ICovCandy<ChocolateСandy> covCandy = new ChocCandyCol();
        // А тут мы можем приравнять к болле обобщенному типу
        // И теперь у нас хоть под капотом и находится тип шоколадной конфеты
        // снаружи он будет под болле обобщенным типом Candy
        ICovCandy<Candy> candyChoc = covCandy;
        Candy candy = candyChoc.GetCandy("А", 2);
        Console.WriteLine(candy.BriefInfo());
    }
}
// Ковариантный интерфейс
public interface ICovCandy<out T>
{
    // Коваринтный метод
    T GetCandy(string name, double price);
}
// Класс реализующий интрефейс
public class ChocCandyCol : ICovCandy<ChocolateСandy>
{
    private List<ChocolateСandy> l = new List<ChocolateСandy>();
    public ChocolateСandy GetCandy(string name, double price)
    {
        ChocolateСandy chocolateСandy = new ChocolateСandy(name,price, new Filling("a",2), new Glaze("b,3",3), new Wrapper("2",5),1);
        l.Add(chocolateСandy);
        return chocolateСandy;
    }
}