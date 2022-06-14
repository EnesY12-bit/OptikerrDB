using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptikerService.Models;

namespace OptikerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mitarbeitersController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public mitarbeitersController()
        {
            _context = new optikerdbContext();
        }

        // GET: api/mitarbeiters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mitarbeiter>>> Getmitarbeiter()
        {
          if (_context.mitarbeiter == null)
          {
              return NotFound();
          }
            return await _context.mitarbeiter.ToListAsync();
        }

        // GET: api/mitarbeiters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mitarbeiter>> Getmitarbeiter(int id)
        {
          if (_context.mitarbeiter == null)
          {
              return NotFound();
          }
            var mitarbeiter = await _context.mitarbeiter.FindAsync(id);

            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return mitarbeiter;
        }


        // POST: api/mitarbeiters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<mitarbeiter>> Postmitarbeiter(mitarbeiter mitarbeiter)
        {
          if (_context.mitarbeiter == null)
          {
              return Problem("Entity set 'optikerdbContext.mitarbeiter'  is null.");
          }
            _context.mitarbeiter.Add(mitarbeiter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (mitarbeiterExists(mitarbeiter.personalid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getmitarbeiter", new { id = mitarbeiter.personalid }, mitarbeiter);
        }

        // DELETE: api/mitarbeiters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemitarbeiter(int id)
        {
            if (_context.mitarbeiter == null)
            {
                return NotFound();
            }
            var mitarbeiter = await _context.mitarbeiter.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            _context.mitarbeiter.Remove(mitarbeiter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool mitarbeiterExists(int id)
        {
            return (_context.mitarbeiter?.Any(e => e.personalid == id)).GetValueOrDefault();
        }
    }
}
