using System.Collections.Generic;
using System.Linq;

namespace DellTddBanking2.Domain
{
    public abstract class Account
    {
        protected List<Transaction> transactions;

        protected Account()
        {
            transactions = new List<Transaction>();
        }

        public decimal CalculateBalance()
        {
            return transactions.Sum(trans => trans.Amount);
        }

        public virtual void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}