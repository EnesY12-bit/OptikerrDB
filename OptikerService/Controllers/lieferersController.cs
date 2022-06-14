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
    public class lieferersController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public lieferersController()
        {
            _context = new optikerdbContext();
        }

        // GET: api/lieferers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<lieferer>>> Getlieferer()
        {
          if (_context.lieferer == null)
          {
              return NotFound();
          }
            return await _context.lieferer.ToListAsync();
        }

        // GET: api/lieferers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<lieferer>> Getlieferer(int id)
        {
          if (_context.lieferer == null)
          {
              return NotFound();
          }
            var lieferer = await _context.lieferer.FindAsync(id);

            if (lieferer == null)
            {
                return NotFound();
            }

            return lieferer;
        }


        // POST: api/lieferers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<lieferer>> Postlieferer(lieferer lieferer)
        {
          if (_context.lieferer == null)
          {
              return Problem("Entity set 'optikerdbContext.lieferer'  is null.");
          }
            _context.lieferer.Add(lieferer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (liefererExists(lieferer.lieferid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getlieferer", new { id = lieferer.lieferid }, lieferer);
        }

        // DELETE: api/lieferers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelieferer(int id)
        {
            if (_context.lieferer == null)
            {
                return NotFound();
            }
            var lieferer = await _context.lieferer.FindAsync(id);
            if (lieferer == null)
            {
                return NotFound();
            }

            _context.lieferer.Remove(lieferer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //PATCH api/lieferers
        [HttpPatch]
        public async Task<ActionResult> Patchlieferer(int id, [FromBody]lieferer clieferer)
        {
            var lieferer = await _context.lieferer.FindAsync(id);
            if (lieferer == null)
            {
                return NotFound();
            }

            lieferer.lieferid = clieferer.lieferid;
            lieferer.name = clieferer.name;
            lieferer.adresse = clieferer.adresse;
            lieferer.email = clieferer.email;
            lieferer.telefonnummer = clieferer.telefonnummer;

            return Ok();
        }

        private bool liefererExists(int id)
        {
            return (_context.lieferer?.Any(e => e.lieferid == id)).GetValueOrDefault();
        }
    }
}
