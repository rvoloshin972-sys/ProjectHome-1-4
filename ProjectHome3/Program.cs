using System;
using System.Text;

namespace ProjectHome3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Predicate<DateTime> checkProgrammerDay = date => date.DayOfYear == 256;

            DateTime date1 = new DateTime(2026, 9, 13);
            DateTime date2 = new DateTime(2026, 9, 12);
            DateTime date3 = new DateTime(2024, 9, 12);

            Console.WriteLine("Перевірка дня програміста");
            Console.WriteLine();

            Console.WriteLine($"Дата: {date1:dd.MM.yyyy}");
            Console.WriteLine($"День програміста: {checkProgrammerDay(date1)}");
            Console.WriteLine();

            Console.WriteLine($"Дата: {date2:dd.MM.yyyy}");
            Console.WriteLine($"День програміста: {checkProgrammerDay(date2)}");
            Console.WriteLine();

            Console.WriteLine($"Дата: {date3:dd.MM.yyyy}");
            Console.WriteLine($"День програміста: {checkProgrammerDay(date3)}");
            Console.ReadKey();
        }
    }
}
