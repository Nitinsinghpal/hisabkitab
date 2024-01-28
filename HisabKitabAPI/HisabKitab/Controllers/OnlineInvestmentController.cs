using HisabKitab.Data;
using HisabKitab.Models.Dairy;
using HisabKitab.Models.OnlineSelling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HisabKitab.Controllers
{
    [Route("api/onlineInvestment")]
    [ApiController]
    public class OnlineInvestmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OnlineInvestmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetDairyPayments()

        {
            return await _context.Investments.ToListAsync();
        }

        // GET: api/DairyPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetDairyPayments(int id)
        {
            var investment = await _context.Investments.FindAsync(id);

            if (investment == null)
            {
                return NotFound();
            }

            return investment;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDairyPayments(int id, Investment investment)
        {
            if (id != investment.Id)
            {
                return BadRequest();
            }

            _context.Entry(investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DairyPaymentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<DairyPayments>> PostDairyPayments(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDairyPayments", new { id = investment.Id }, investment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDairyPayments(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }

            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DairyPaymentsExists(int id)
        {
            return _context.Investments.Any(e => e.Id == id);
        }
    }
}
