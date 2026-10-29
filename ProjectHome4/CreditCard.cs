using System;

namespace ProjectHome4
{
    internal class CreditCard
    {
        public string CardNumber { get; private set; }
        public string OwnerName { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        private string Pin { get; set; }
        public decimal CreditLimit { get; private set; }
        public decimal Balance { get; private set; }
        public decimal CreditUsed => Math.Max(0, -Balance);
        public event Action<CreditCard, CreditCardEventArgs>? AccountReplenished;
        public event Action<CreditCard, CreditCardEventArgs>? MoneySpent;
        public event Action<CreditCard, CreditCardEventArgs>? CreditStarted;
        public event Action<CreditCard, CreditCardEventArgs>? CreditLimitReached;
        public event Action<CreditCard, CreditCardEventArgs>? PinChanged;
        public CreditCard(string cardNumber,string ownerName,DateTime expiryDate,string pin,decimal creditLimit,decimal balance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = balance;
        }
        public void Replenish(decimal amount)
        {
            Balance += amount;
            AccountReplenished?.Invoke(this,new CreditCardEventArgs($"Рахунок поповнено на {amount} грн.", amount));
        }
        public void Spend(decimal amount)
        {
            decimal previousCredit = CreditUsed;
            decimal available = Math.Max(0, Balance + CreditLimit);
            decimal actualAmount = Math.Min(amount, available);

            bool wasUsingCredit = Balance < 0;
            Balance -= actualAmount;
            bool isUsingCredit = Balance < 0;
            decimal currentCredit = CreditUsed;

            MoneySpent?.Invoke(this,new CreditCardEventArgs($"Витрачено {actualAmount} грн.", actualAmount));

            Action? startNotification = !wasUsingCredit && isUsingCredit
                ? () => CreditStarted?.Invoke(this,new CreditCardEventArgs("Розпочато використання кредитних коштів.",currentCredit))
                : null;

            startNotification?.Invoke();
            Action? limitNotification = previousCredit < CreditLimit && currentCredit >= CreditLimit
                ? () => CreditLimitReached?.Invoke(this,new CreditCardEventArgs("Досягнуто кредитного ліміту!",currentCredit))
                : null;
            limitNotification?.Invoke();
        }
        public void ChangePin(string newPin)
        {
            Pin = newPin;
            PinChanged?.Invoke(this,new CreditCardEventArgs("PIN-код успішно змінено.", 0));
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Номер картки: {CardNumber}");
            Console.WriteLine($"Власник: {OwnerName}");
            Console.WriteLine($"Термін дії: {ExpiryDate:MM/yyyy}");
            Console.WriteLine($"Кредитний ліміт: {CreditLimit} грн.");
            Console.WriteLine($"Баланс: {Balance} грн.");
            Console.WriteLine($"Використано кредиту: {CreditUsed} грн.");
        }

    }
}
