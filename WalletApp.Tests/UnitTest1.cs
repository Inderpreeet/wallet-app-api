using WalletApp.Library.Services;
using Xunit;

namespace WalletApp.Tests
{
    public class BudgetCalculatorTests
    {
        [Fact]
        public void CalculateRemainingBudget_ReturnsCorrectValue()
        {
            var calculator = new BudgetCalculator();
            var result = calculator.CalculateRemainingBudget(1000m, 400m);

            Assert.Equal(600m, result);
        }

        [Fact]
        public void CalculateRemainingBudget_ThrowsOnNegativeInputs()
        {
            var calculator = new BudgetCalculator();

            Assert.Throws<ArgumentException>(() => calculator.CalculateRemainingBudget(-100m, 50m));
            Assert.Throws<ArgumentException>(() => calculator.CalculateRemainingBudget(100m, -50m));
        }
    }
}

