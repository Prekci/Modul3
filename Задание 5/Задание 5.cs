using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    // Делегат для методов сортировки
    delegate void SortMethodDelegate(int[] arr);
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите метод сортировки:");
                Console.WriteLine("1. Сортировка пузырьком");
                Console.WriteLine("2. Сортировка деревом");
                Console.WriteLine("3. Сортировка гномья");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RunSort("Сортировка пузырьком", BubbleSort);
                        break;
                    case "2":
                        RunSort("Сортировка деревом", HeapSort);
                        break;
                    case "3":
                        RunSort("Сортировка гномья", GnomeSort);
                        break;
                    default:
                        Console.WriteLine("Выберите метод сортировки из списка");
                        break;
                }
            }
        }
        // Метод для выполнения выбранной сортировки
        static void RunSort(string sortName, SortMethodDelegate sortMethod)
        {
            Console.WriteLine($"Выбрали {sortName}");
            Console.Write("Введите элементы массива через пробел: ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');
            int[] arr = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                // Проверяем, является ли введенное значение числом
                if (int.TryParse(inputArray[i], out int num))
                {
                    arr[i] = num;
                }
                else
                {
                    Console.WriteLine("Введите числа через пробел\n");
                    return;
                }
            }
            Console.WriteLine("Исходный массив:");
            PrintArray(arr);
            sortMethod(arr); // Вызываем выбранный метод сортировки
            Console.WriteLine("Отсортированный массив:");
            PrintArray(arr);
        }
        // Метод сортировки пузырьком
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        // Метод сортировки деревом (Heap Sort)
        static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }
        // Метод для преобразования массива в кучу
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest);
            }
        }
        // Метод сортировки гномья
        static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int index = 0;
            while (index < n)
            {
                if (index == 0)
                {
                    index++;
                }
                if (arr[index] >= arr[index - 1])
                {
                    index++;
                }
                else
                {
                    int temp = arr[index];
                    arr[index] = arr[index - 1];
                    arr[index - 1] = temp;
                    index--;
                }
            }
        }
        // Метод для вывода массива на экран
        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }
}