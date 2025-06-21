namespace WalletApp.Library.Services
{
    public class BudgetCalculator
    {
        public decimal CalculateRemainingBudget(decimal totalBudget, decimal expenses)
        {
            if (expenses < 0 || totalBudget < 0)
            {
                throw new ArgumentException("Values must be non-negative");
            }

            return totalBudget - expenses;
        }
    }
}
