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
    public class kundensController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public kundensController()
        {
            _context = new optikerdbContext();
        }

        // GET: api/kundens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<kunden>>> Getkunden()
        {
          if (_context.kunden == null)
          {
              return NotFound();
          }
            return await _context.kunden.ToListAsync();
        }

        // GET: api/kundens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<kunden>> Getkunden(int id)
        {
          if (_context.kunden == null)
          {
              return NotFound();
          }
            var kunden = await _context.kunden.FindAsync(id);

            if (kunden == null)
            {
                return NotFound();
            }

            return kunden;
        }

        // PUT: api/kundens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putkunden(int id, kunden kunden)
        {
            if (id != kunden.kundenid)
            {
                return BadRequest();
            }

            _context.Entry(kunden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kundenExists(id))
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

        // POST: api/kundens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<kunden>> Postkunden(kunden kunden)
        {
          if (_context.kunden == null)
          {
              return Problem("Entity set 'optikerdbContext.kunden'  is null.");
          }
            _context.kunden.Add(kunden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (kundenExists(kunden.kundenid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getkunden", new { id = kunden.kundenid }, kunden);
        }

        // DELETE: api/kundens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletekunden(int id)
        {
            if (_context.kunden == null)
            {
                return NotFound();
            }
            var kunden = await _context.kunden.FindAsync(id);
            if (kunden == null)
            {
                return NotFound();
            }

            _context.kunden.Remove(kunden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool kundenExists(int id)
        {
            return (_context.kunden?.Any(e => e.kundenid == id)).GetValueOrDefault();
        }
    }
}
