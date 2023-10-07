using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Задание_2
{
    // Класс Уведомление представляет события для отправки уведомлений разных типов.
    public class Уведомление
    {
        // Событие для отправки сообщения
        public event EventHandler<MessageEventArgs> SendMessage;
        // Событие для отправки звонка
        public event EventHandler<CallEventArgs> MakeCall;
        // Событие для отправки электронного письма
        public event EventHandler<EmailEventArgs> SendEmail;
        // Метод для отправки сообщения
        public void ОтправитьСообщение(string сообщение)
        {
            SendMessage?.Invoke(this, new MessageEventArgs(сообщение));
        }
        // Метод для отправки звонка
        public void СделатьЗвонок(string номер)
        {
            MakeCall?.Invoke(this, new CallEventArgs(номер));
        }
        // Метод для отправки электронного письма
        public void ОтправитьEmail(string адрес, string тема)
        {
            SendEmail?.Invoke(this, new EmailEventArgs(адрес, тема));
        }
    }
    // Класс MessageEventArgs представляет аргументы события отправки сообщения
    public class MessageEventArgs : EventArgs
    {
        public string Сообщение { get; }
        public MessageEventArgs(string сообщение)
        {
            Сообщение = сообщение;
        }
    }
    // Класс CallEventArgs представляет аргументы события отправки звонка
    public class CallEventArgs : EventArgs
    {
        public string Номер { get; }
        public CallEventArgs(string номер)
        {
            Номер = номер;
        }
    }
    // Класс EmailEventArgs представляет аргументы события отправки электронного письма
    public class EmailEventArgs : EventArgs
    {
        public string Адрес { get; }
        public string Тема { get; }
        public EmailEventArgs(string адрес, string тема)
        {
            Адрес = адрес;
            Тема = тема;
        }
    }
    // Класс для обработчика события отправки сообщения
    public class MessageHandler
    {
        public void ОтправкаСообщения(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Отправлено сообщение: {e.Сообщение}\n");
        }
    }
    // Класс для обработчика события отправки звонка
    public class CallHandler
    {
        public void СовершениеЗвонка(object sender, CallEventArgs e)
        {
            Console.WriteLine($"Совершен звонок на номер: {e.Номер}\n");
        }
    }
    // Класс для обработчика события отправки электронного письма
    public class EmailHandler
    {
        public void ОтправкаЭлектронногоПисьма(object sender, EmailEventArgs e)
        {
            Console.WriteLine($"Отправлено электронное письмо на адрес {e.Адрес} с темой: {e.Тема}\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта класса Уведомление
            Уведомление уведомление = new Уведомление();
            // Создание обработчиков событий для разных типов уведомлений
            MessageHandler messageHandler = new MessageHandler();
            CallHandler callHandler = new CallHandler();
            EmailHandler emailHandler = new EmailHandler();
            // Подписка на события отправки уведомлений
            уведомление.SendMessage += messageHandler.ОтправкаСообщения;
            уведомление.MakeCall += callHandler.СовершениеЗвонка;
            уведомление.SendEmail += emailHandler.ОтправкаЭлектронногоПисьма;
            while (true)
            {
                Console.WriteLine("Выберите тип уведомления:");
                Console.WriteLine("1. Отправить сообщение");
                Console.WriteLine("2. Сделать звонок");
                Console.WriteLine("3. Отправить электронное письмо");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите сообщение: ");
                        string сообщение = Console.ReadLine();
                        уведомление.ОтправитьСообщение(сообщение);
                        break;
                    case "2":
                        Console.Write("Введите номер телефона: ");
                        string номерТелефона = Console.ReadLine();
                        if (!IsValidNumber(номерТелефона))
                        {
                            Console.WriteLine("Номер телефона может содержать только цифры.");
                            Console.ReadLine();
                            return;
                        }
                        уведомление.СделатьЗвонок(номерТелефона);
                        break;
                    case "3":
                        Console.Write("Введите адрес электронной почты: ");
                        string адресПочты = Console.ReadLine();
                        if (!IsValidEmail(адресПочты))
                        {
                            Console.WriteLine("Адрес электронной почты может состоять из английских букв, цифр и символов.");
                            Console.ReadLine();
                            return;
                        }
                        else
                        {
                            Console.Write("Введите тему письма: ");
                            string тема = Console.ReadLine();
                            уведомление.ОтправитьEmail(адресПочты, тема);
                            
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
        // Метод для проверки, что строка состоит только из английских букв, цифр и символов
        static bool IsValidEmail(string адресПочты)
        {
            return Regex.IsMatch(адресПочты, @"^[a-zA-Z0-9@.]+$");
        }
        // Метод для проверки, что строка состоит только из цифр
        static bool IsValidNumber(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]+$");
        }
    }
}
