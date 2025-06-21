using WalletApp.Library.Models;
using WalletApp.Library.Services;
using Xunit;

namespace WalletApp.Tests
{
    public class TransactionServiceTests
    {
        [Fact]
        public void AddTransaction_ShouldIncreaseTransactionCount()
        {
            var service = new TransactionService();
            service.AddTransaction(new Transaction { Type = "Expense", Amount = 100 });
            Assert.Single(service.GetAllTransactions());
        }

        [Fact]
        public void GetAllTransactions_ShouldReturnAllTransactions()
        {
            var service = new TransactionService();
            service.AddTransaction(new Transaction { Type = "Income", Amount = 200 });
            service.AddTransaction(new Transaction { Type = "Expense", Amount = 100 });

            var transactions = service.GetAllTransactions();
            Assert.Equal(2, transactions.Count);
        }

        [Fact]
        public void GetTotalSpent_ShouldReturnSumOfOnlyExpenses()
        {
            var service = new TransactionService();
            service.AddTransaction(new Transaction { Type = "Income", Amount = 500 });
            service.AddTransaction(new Transaction { Type = "Expense", Amount = 150 });
            service.AddTransaction(new Transaction { Type = "Expense", Amount = 50 });

            var totalSpent = service.GetTotalSpent();
            Assert.Equal(200, totalSpent);
        }

        [Fact]
        public void AddTransaction_ShouldAddMultipleTransactions()
        {
            var service = new TransactionService();
            service.AddTransaction(new Transaction { Type = "Expense", Amount = 100 });
            service.AddTransaction(new Transaction { Type = "Income", Amount = 200 });

            Assert.Equal(2, service.GetAllTransactions().Count);
        }

        [Fact]
        public void GetAllTransactions_ShouldReturnEmptyList_Initially()
        {
            var service = new TransactionService();
            var transactions = service.GetAllTransactions();

            Assert.Empty(transactions);
        }

        [Fact]
        public void GetTotalSpent_ShouldReturnZero_WhenNoExpenses()
        {
            var service = new TransactionService();
            service.AddTransaction(new Transaction { Type = "Income", Amount = 500 });

            var total = service.GetTotalSpent();
            Assert.Equal(0, total);
        }
    }
}
