using WalletApp.Library.Models;

namespace WalletApp.Library.Services
{
    public class TransactionService
    {
        private readonly List<Transaction> _transactions = new();

        public void AddTransaction(Transaction t)
        {
            _transactions.Add(t);
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public decimal GetTotalSpent()
        {
            return _transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);
        }
    }
}
