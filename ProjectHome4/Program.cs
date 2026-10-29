using System;
using System.Text;
using static System.Console;

namespace ProjectHome4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            CreditCard card = new CreditCard("4444-5555-6666-7777","Іваненко Іван Іванович",new DateTime(2029, 12, 31),"1234",1000m,500m);
            card.AccountReplenished += DisplayMessage;
            card.MoneySpent += DisplayMessage;
            card.CreditStarted += DisplayMessage;
            card.CreditLimitReached += DisplayMessage;
            card.PinChanged += DisplayMessage;

            Console.WriteLine(" КРЕДИТНА КАРТКА ");
            card.DisplayInfo();

            Console.WriteLine("\n ПОПОВНЕННЯ РАХУНКУ ");
            card.Replenish(300m);

            Console.WriteLine("\n ВИТРАТА ВЛАСНИХ КОШТІВ ");
            card.Spend(600m);

            Console.WriteLine("\n ВИКОРИСТАННЯ КРЕДИТНИХ КОШТІВ ");
            card.Spend(700m);

            Console.WriteLine("\n ДОСЯГНЕННЯ КРЕДИТНОГО ЛІМІТУ ");
            card.Spend(500m);

            Console.WriteLine("\n ЗМІНА PIN-КОДУ ");
            card.ChangePin("5678");

            Console.WriteLine("\n ПІДСУМКОВА ІНФОРМАЦІЯ ");
            card.DisplayInfo();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
        static void DisplayMessage(CreditCard sender,CreditCardEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Сума операції: {e.Amount} грн.");
            Console.WriteLine($"Поточний баланс: {sender.Balance} грн.");
        }
    }
}
