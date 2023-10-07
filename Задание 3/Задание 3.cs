using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Задание_3
{
    // Делегат для выполнения задачи
    delegate void TaskDelegate(string taskName);
    // Класс для управления задачами
    class TaskManager
    {
        private List<string> tasks = new List<string>();
        // Метод для добавления задачи
        public void AddTask(string taskName)
        {
            tasks.Add(taskName);
        }
        // Метод для выполнения всех задач с использованием выбранного делегата
        public void ExecuteTasks(TaskDelegate taskDelegate)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Выполняется задача: {task}");
                taskDelegate?.Invoke(task);
            }
        }
    }
    class Program
    {
        // Метод для записи задачи в журнал
        static void LogTask(string taskName)
        {
            Console.WriteLine($"Задача \"{taskName}\" записана в журнал");
        }
        // Метод для отправки уведомления о задаче
        static void NotifyTask(string taskName)
        {
            Console.WriteLine($"Уведомление: Задача \"{taskName}\" выполнена");
        }
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи с записью в журнал");
                Console.WriteLine("3. Выполнить задачи с отправкой уведомления");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();
                        taskManager.AddTask(taskName);
                        if (!IsValidRussianName(taskName))
                        {
                            // Если это не так то
                            // Вывод сообщения об ошибке
                            Console.WriteLine("Название задачи должно состоять только из русских букв");
                            Console.ReadLine();
                            return; // Завершение выполнения программы
                        }
                        break;
                    case "2":
                        Console.WriteLine("Выполнение задач с записью в журнал:");
                        taskManager.ExecuteTasks(LogTask);
                        break;
                    case "3":
                        Console.WriteLine("Выполнение задач с отправкой уведомления:");
                        taskManager.ExecuteTasks(NotifyTask);
                        break;
                    default:
                        Console.WriteLine("Выберите действие из списка");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        } 
        // Метод для проверки, что строка состоит только из русских букв
        static bool IsValidRussianName(string taskName)
        {
            // Проверка, что строка состоит только из русских букв
            return Regex.IsMatch(taskName, @"^[А-Яа-я ]+$", RegexOptions.IgnoreCase);
        }
    }
}