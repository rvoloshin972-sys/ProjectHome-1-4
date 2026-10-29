using System;

namespace ProjectHome4
{
    internal class CreditCardEventArgs : EventArgs
    {
        public string Message { get; }
        public decimal Amount { get; }
        public CreditCardEventArgs(string message, decimal amount)
        {
            Message = message;
            Amount = amount;
        }
    }
}
