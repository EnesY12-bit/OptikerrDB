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

        // POST: api/kundens
        [HttpPost]
        public async Task<ActionResult<kunden>> Postkunden(int KID, kunden kunden)
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

            return CreatedAtAction("Getkunden", new { id = KID }, kunden);
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

        // PATCH api/kundens
        [HttpPatch]
        public async Task<ActionResult> Patchkunden(int id, [FromBody] kunden ckunden)
        {
            var kunden = await _context.kunden.FindAsync(id);
            if (_context.kunden == null)
            {
                return NotFound();
            }
            
            kunden.kundenid = ckunden.kundenid;
            kunden.anrede = ckunden.anrede;
            kunden.name = ckunden.name;
            kunden.email = ckunden.email;
            kunden.telefonnummer = ckunden.telefonnummer;
            kunden.anrede = ckunden.adresse;
            kunden.kosten = ckunden.kosten;
            kunden.bestellungsnummer = ckunden.bestellungsnummer;
            kunden.datum = ckunden.datum;

            return Ok();

        }
        private bool kundenExists(int id)
        {
            return (_context.kunden?.Any(e => e.kundenid == id)).GetValueOrDefault();
        }
    }
}
