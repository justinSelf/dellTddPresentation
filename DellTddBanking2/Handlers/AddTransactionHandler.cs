using DellTddBanking2.Bus;
using DellTddBanking2.Commands;
using DellTddBanking2.Domain;
using DellTddBanking2.Events;

namespace DellTddBanking2.Handlers
{
    public class AddTransactionHandler : IHandleMessages<AddTransaction>
    {
        private readonly Bus.Bus Bus;

        public AddTransactionHandler()
        {
            Bus = new Bus.Bus();
        }

        public void Handle(AddTransaction message)
        {
            message.Account.AddTransaction(message.Transaction);

            if (message.Account.CalculateBalance() < 0)
            {
                Bus.Publish(new AccountIsOverdrawn
                {
                    Account = message.Account as CheckingAccount,
                    Customer = message.Customer
                });
            }
        }
    }
}