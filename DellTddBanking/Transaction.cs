namespace DellTddBanking
{
    public class Transaction
    {
        public decimal Amount { get; set; }

        public Transaction(decimal amount)
        {
            Amount = amount;
        }
    }
}