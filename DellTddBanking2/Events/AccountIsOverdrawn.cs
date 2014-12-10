using DellTddBanking2.Bus;
using DellTddBanking2.Domain;

namespace DellTddBanking2.Events
{
    public class AccountIsOverdrawn : IEvent
    {
        public CheckingAccount Account { get; set; }
        public Customer Customer { get; set; }
    }
}