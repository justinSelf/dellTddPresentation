using DellTddBanking2.Bus;
using DellTddBanking2.Domain;

namespace DellTddBanking2.Commands
{
    public class AddTransaction : ICommand
    {
        public Transaction Transaction { get; set; }
        public Customer Customer { get; set; }
        public Account Account { get; set; }
    }
}