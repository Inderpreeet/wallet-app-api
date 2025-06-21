using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Library.Models;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private static List<Transaction> _transactions = new();
        private static int _nextId = 1;

        // ✅ GET all transactions
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_transactions);
        }

        // ✅ GET transaction by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        // ✅ POST create transaction
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            transaction.Id = _nextId++;
            transaction.Date = DateTime.UtcNow;
            _transactions.Add(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        // ✅ PUT update transaction
        [HttpPut("{id}")]
        public IActionResult Update(int id, Transaction updated)
        {
            var existing = _transactions.FirstOrDefault(t => t.Id == id);
            if (existing == null)
                return NotFound();

            existing.Type = updated.Type;
            existing.Amount = updated.Amount;
            existing.Description = updated.Description;
            existing.Category = updated.Category;
            return NoContent();
        }

        // ✅ DELETE transaction
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                return NotFound();

            _transactions.Remove(transaction);
            return NoContent();
        }

        // 🎯 Ancillary 1: Get totals grouped by category
        [HttpGet("by-category")]
        public IActionResult GetByCategory()
        {
            var grouped = _transactions
                .GroupBy(t => t.Category ?? "Uncategorized")
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => t.Amount)
                });

            return Ok(grouped);
        }

        // 🎯 Ancillary 2: Monthly income/expense summary
        [HttpGet("monthly-summary")]
        public IActionResult GetMonthlySummary()
        {
            var now = DateTime.UtcNow;
            var monthTransactions = _transactions
                .Where(t => t.Date.Month == now.Month && t.Date.Year == now.Year);

            var income = monthTransactions
                .Where(t => t.Type == "Income")
                .Sum(t => t.Amount);

            var expense = monthTransactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

            return Ok(new
            {
                Income = income,
                Expense = expense,
                Net = income - expense
            });
        }
    }
}



