using System.Collections.Generic;
using System.Linq;

namespace DellTddBanking
{
    public class CheckingAccount
    {
        private List<Transaction> transactions;

        public CheckingAccount()
        {
            transactions = new List<Transaction>();
        }
        public decimal CalculateBalance()
        {
            return transactions.Sum(trans => trans.Amount);
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }


        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}