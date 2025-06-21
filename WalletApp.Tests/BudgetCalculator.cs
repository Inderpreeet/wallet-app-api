using WalletApp.Library.Services;
using Xunit;

namespace WalletApp.Tests
{
    public class BudgetCalculatorTests
    {
        [Fact]
        public void CalculateRemainingBudget_ReturnsCorrectDifference()
        {
            var calculator = new BudgetCalculator();
            var result = calculator.CalculateRemainingBudget(1000m, 250m);
            Assert.Equal(750m, result);
        }

        [Fact]
        public void CalculateRemainingBudget_WithZeroExpenses_ReturnsTotalBudget()
        {
            var calculator = new BudgetCalculator();
            var result = calculator.CalculateRemainingBudget(500m, 0m);
            Assert.Equal(500m, result);
        }

        [Fact]
        public void CalculateRemainingBudget_WithEqualBudgetAndExpense_ReturnsZero()
        {
            var calculator = new BudgetCalculator();
            var result = calculator.CalculateRemainingBudget(300m, 300m);
            Assert.Equal(0m, result);
        }

        [Fact]
        public void CalculateRemainingBudget_WithNegativeBudget_ThrowsException()
        {
            var calculator = new BudgetCalculator();
            Assert.Throws<ArgumentException>(() => calculator.CalculateRemainingBudget(-100m, 50m));
        }

        [Fact]
        public void CalculateRemainingBudget_WithNegativeExpenses_ThrowsException()
        {
            var calculator = new BudgetCalculator();
            Assert.Throws<ArgumentException>(() => calculator.CalculateRemainingBudget(200m, -10m));
        }

        [Fact]
        public void CalculateRemainingBudget_WithLargeValues_ReturnsCorrectResult()
        {
            var calculator = new BudgetCalculator();
            var result = calculator.CalculateRemainingBudget(1_000_000m, 750_000m);
            Assert.Equal(250_000m, result);
        }
    }
}


