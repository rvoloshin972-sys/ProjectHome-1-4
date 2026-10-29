
using System;
using System.Text;

namespace ProjectHome1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            DayTemperature[] temperatures =
            {
                new DayTemperature("Понеділок", 15, 5),
                new DayTemperature("Вівторок", 18, 8),
                new DayTemperature("Середа", 12, -2),
                new DayTemperature("Четвер", 20, 10),
                new DayTemperature("П'ятниця", 16, 3),
                new DayTemperature("Субота", 10, -5),
                new DayTemperature("Неділя", 14, 4)
            };
            Console.WriteLine("Температури за тиждень:");
            Console.WriteLine();
            foreach (DayTemperature day in temperatures)
            {
                Console.WriteLine(
                    $"{day.Day}: найвища {day.MaxTemperature}°C, " +
                    $"найнижча {day.MinTemperature}°C, " +
                    $"різниця {day.Difference}°C");
            }
            DayTemperature result = temperatures.GetDayWithMaxDifference();
            Console.WriteLine();
            Console.WriteLine("День із максимальною різницею температур:");
            Console.WriteLine($"День: {result.Day}");
            Console.WriteLine($"Найвища температура: {result.MaxTemperature}°C");
            Console.WriteLine($"Найнижча температура: {result.MinTemperature}°C");
            Console.WriteLine($"Різниця температур: {result.Difference}°C");
            Console.ReadKey();
        }
    }
}
