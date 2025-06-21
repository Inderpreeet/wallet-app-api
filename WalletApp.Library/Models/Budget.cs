namespace WalletApp.Library.Models
{
    public class Budget
    {
        public decimal Limit { get; set; }
        public decimal Spent { get; set; }

        public decimal Remaining => Limit - Spent;
    }
}
