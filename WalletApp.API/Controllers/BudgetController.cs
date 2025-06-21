using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Library.Models;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BudgetController : ControllerBase
    {
        private static List<Budget> _budgets = new();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_budgets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var budget = _budgets.FirstOrDefault(b => b.Id == id);
            if (budget == null) return NotFound();
            return Ok(budget);
        }

        [HttpPost]
        public IActionResult Create(Budget budget)
        {
            budget.Id = _nextId++;
            _budgets.Add(budget);
            return CreatedAtAction(nameof(GetById), new { id = budget.Id }, budget);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Budget updated)
        {
            var existing = _budgets.FirstOrDefault(b => b.Id == id);
            if (existing == null) return NotFound();

            existing.Amount = updated.Amount;
            existing.Category = updated.Category;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var budget = _budgets.FirstOrDefault(b => b.Id == id);
            if (budget == null) return NotFound();

            _budgets.Remove(budget);
            return NoContent();
        }
    }
}
