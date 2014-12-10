using DellTddBanking2.Bus;
using DellTddBanking2.Domain;
using DellTddBanking2.Events;

namespace DellTddBanking2.Handlers
{
    public class PerformEmergencyTransfer : IHandleMessages<AccountIsOverdrawn>
    {
        public void Handle(AccountIsOverdrawn message)
        {
            var balance = message.Account.CalculateBalance();
            var overDrawnAmount = 0 - balance;

            var debitTransaction = new Transaction(balance - 1);
            var creditTransaction = new Transaction(overDrawnAmount + 1);

            message.Customer.SavingsAccount.AddTransaction(debitTransaction);
            message.Customer.CheckingAccount.AddTransaction(creditTransaction);
        }
    }
}