using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    // Базовый класс фигура
    class Shape
    {
        // Метод для вычисления площади фигуры
        public virtual double CalculateArea()
        {
            return 0.0;
        }
    }
    // Производный класс круг
    class Circle : Shape
    {
        private double radius;
        // Конструктор класса Circle, принимает радиус
        public Circle(double radius)
        {
            this.radius = radius;
        }
        // Переопределение метода для вычисления площади круга
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
    // Производный класс "Прямоугольник"
    class Rectangle : Shape
    {
        private double width;
        private double height;
        // Конструктор класса Rectangle, принимает ширину и высоту
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        // Переопределение метода для вычисления площади прямоугольника
        public override double CalculateArea()
        {
            return width * height;
        }
    }
    // Производный класс "Треугольник"
    class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;
        // Конструктор класса Triangle, принимает длины сторон
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        // Переопределение метода для вычисления площади треугольника по формуле Герона
        public override double CalculateArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем делегат для вычисления площади фигуры
            Func<Shape, double> AreaDelegate = (shape) => shape.CalculateArea();
            while (true)
            {
                Console.WriteLine("Выберите фигуру: ");
                Console.WriteLine("1. Круг");
                Console.WriteLine("2. Прямоугольник");
                Console.WriteLine("3. Треугольник");
                // Считываем выбор пользователя
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите радиус круга: ");
                        if (double.TryParse(Console.ReadLine(), out double radius) && radius > 0)
                        {
                            // Создаем объект класса "Круг"
                            Circle circle = new Circle(radius);
                            // Вычисляем площадь с использованием делегата
                            double area = AreaDelegate(circle);
                            Console.WriteLine($"Площадь круга: {area:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод радиуса");
                        }
                        break;
                    case "2":
                        Console.Write("Введите ширину прямоугольника: ");
                        if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
                        {
                            Console.Write("Введите высоту прямоугольника: ");
                            if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
                            {
                                // Создаем объект класса "Прямоугольник"
                                Rectangle rectangle = new Rectangle(width, height);
                                // Вычисляем площадь с использованием делегата
                                double rectangleArea = AreaDelegate(rectangle);
                                Console.WriteLine($"Площадь прямоугольника: {rectangleArea:F2}");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод высоты");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ширины");
                        }
                        break;
                    case "3":
                        Console.Write("Введите длину стороны a: ");
                        if (double.TryParse(Console.ReadLine(), out double sideA) && sideA > 0)
                        {
                            Console.Write("Введите длину стороны b: ");
                            if (double.TryParse(Console.ReadLine(), out double sideB) && sideB > 0)
                            {
                                Console.Write("Введите длину стороны c: ");
                                if (double.TryParse(Console.ReadLine(), out double sideC) && sideC > 0)
                                {
                                    if ((sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA)
                                    {
                                        // Создаем объект класса "Треугольник"
                                        Triangle triangle = new Triangle(sideA, sideB, sideC);
                                        // Вычисляем площадь с использованием делегата
                                        double triangleArea = AreaDelegate(triangle);
                                        Console.WriteLine($"Площадь треугольника: {triangleArea:F2}");
                                    } 
                                    else 
                                    {
                                    Console.WriteLine("Сумма двух сторон треугольника меньше либо равна третьей. Введите другие параметры сторон. ");
                                    }
                                }
                                   
                                else
                                {
                                    Console.WriteLine("Некорректный ввод длины стороны c");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод длины стороны b");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод длины стороны a");
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }
    }
}
