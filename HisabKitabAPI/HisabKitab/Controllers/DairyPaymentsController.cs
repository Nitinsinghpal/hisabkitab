using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HisabKitab.Data;
using HisabKitab.Models.Dairy;

namespace HisabKitab.Controllers
{
    [Route("api/dairyPayments")]
    [ApiController]
    public class DairyPaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DairyPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DairyPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DairyPayments>>> GetDairyPayments()
        
        {
            return await _context.DairyPayments.ToListAsync();
        }

        // GET: api/DairyPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DairyPayments>> GetDairyPayments(int id)
        {
            var dairyPayments = await _context.DairyPayments.FindAsync(id);

            if (dairyPayments == null)
            {
                return NotFound();
            }

            return dairyPayments;
        }

        // PUT: api/DairyPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDairyPayments(int id, DairyPayments dairyPayments)
        {
            if (id != dairyPayments.Id)
            {
                return BadRequest();
            }

            _context.Entry(dairyPayments).State = EntityState.Modified;

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

        // POST: api/DairyPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DairyPayments>> PostDairyPayments(DairyPayments dairyPayments)
        {
            _context.DairyPayments.Add(dairyPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDairyPayments", new { id = dairyPayments.Id }, dairyPayments);
        }

        // DELETE: api/DairyPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDairyPayments(int id)
        {
            var dairyPayments = await _context.DairyPayments.FindAsync(id);
            if (dairyPayments == null)
            {
                return NotFound();
            }

            _context.DairyPayments.Remove(dairyPayments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DairyPaymentsExists(int id)
        {
            return _context.DairyPayments.Any(e => e.Id == id);
        }
    }
}
