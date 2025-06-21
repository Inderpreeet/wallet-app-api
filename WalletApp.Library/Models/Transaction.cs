namespace WalletApp.Library.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; } // "Income" or "Expense"
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
