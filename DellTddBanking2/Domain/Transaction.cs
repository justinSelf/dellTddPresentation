using System;

namespace DellTddBanking2.Domain
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount)
        {
            Amount = amount;
        }
    }
}