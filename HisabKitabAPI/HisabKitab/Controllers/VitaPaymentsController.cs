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
    [Route("api/vitaPayments")]
    [ApiController]
    public class VitaPaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VitaPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VitaPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VitaPayments>>> GetVitaPayments()
        {
            var data = await _context.VitaPayments.ToListAsync();
            return data;
        }

        // GET: api/VitaPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VitaPayments>> GetVitaPayments(int id)
        {
            var vitaPayments = await _context.VitaPayments.FindAsync(id);

            if (vitaPayments == null)
            {
                return NotFound();
            }

            return vitaPayments;
        }

        // PUT: api/VitaPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitaPayments(int id, VitaPayments vitaPayments)
        {
            if (id != vitaPayments.Id)
            {
                return BadRequest();
            }

            _context.Entry(vitaPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitaPaymentsExists(id))
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

        // POST: api/VitaPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VitaPayments>> PostVitaPayments(VitaPayments vitaPayments)
        {
            _context.VitaPayments.Add(vitaPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVitaPayments", new { id = vitaPayments.Id }, vitaPayments);
        }

        // DELETE: api/VitaPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitaPayments(int id)
        {
            var vitaPayments = await _context.VitaPayments.FindAsync(id);
            if (vitaPayments == null)
            {
                return NotFound();
            }

            _context.VitaPayments.Remove(vitaPayments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VitaPaymentsExists(int id)
        {
            return _context.VitaPayments.Any(e => e.Id == id);
        }
    }
}
