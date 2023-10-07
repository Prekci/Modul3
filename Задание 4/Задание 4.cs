using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        // Делегат для фильтрации данных
        delegate IEnumerable<string> DataFilterDelegate(IEnumerable<string> data);
        static void Main(string[] args)
        {
            // Создаем список данных (список строк)
            List<string> data = new List<string>
        {
            "Сегодня погода отличная!",
            "Завтра будет облачно с прояснениями.",
            "Сегодняшние я должен сходить на концерт и встретиться с друзьями.",
            "Важное напоминание: оплатить счета до конца месяца.",
            "Нужно сходить в магазин за продуктами."
        };
            while (true)
            {
                Console.WriteLine("\nДоступные данные:");
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Выберите фильтр для списка данных:");
                Console.WriteLine("1. Фильтр по ключевым словам");
                Console.WriteLine("2. Фильтр по длине строки");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите ключевое слово для фильтрации: ");
                        string keyword = Console.ReadLine();
                        var filteredByKeyword = FilterData(data, FilterByKeyword(keyword));
                        if (filteredByKeyword.Any())
                        {
                            PrintFilteredData(filteredByKeyword);
                        }
                        else
                        {
                            Console.WriteLine("Совпадений не найдено");
                        }
                        break;
                    case "2":
                        Console.Write("Введите минимальную длину строки для фильтрации: ");
                        if (int.TryParse(Console.ReadLine(), out int minLength))
                        {
                            var filteredByLength = FilterData(data, FilterByLength(minLength));
                            if (filteredByLength.Any())
                            {
                                PrintFilteredData(filteredByLength);
                            }
                            else
                            {
                                Console.WriteLine("Совпадений не найдено");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод"); 
                        }
                        break;
                    default:
                        Console.WriteLine("Выберите фильтр из списка");
                        break;
                }
            }
        }
        // Метод для фильтрации данных с использованием делегата
        static IEnumerable<string> FilterData(IEnumerable<string> data, DataFilterDelegate filterDelegate)
        {
            return filterDelegate(data);
        }
        // Метод для вывода отфильтрованных данных
        static void PrintFilteredData(IEnumerable<string> filteredData)
        {
            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
        }
        // Метод для фильтрации данных по ключевым словам
        static DataFilterDelegate FilterByKeyword(string keyword)
        {
            return data => data.Where(item => item.Contains(keyword));
        }
        // Метод для фильтрации данных по длине строки
        static DataFilterDelegate FilterByLength(int minLength)
        {
            return data => data.Where(item => item.Length >= minLength);
        }
    }
}