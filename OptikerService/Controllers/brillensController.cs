using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptikerService.Models;
using System.Text.Json;

namespace OptikerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class brillensController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public brillensController(optikerdbContext _context)
        {
            _context = new optikerdbContext();
        }

        // GET: api/brillens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<brillen>>> Getbrillen()
        {
          if (_context.brillen == null)
          {
              return NotFound();
          }
            return await _context.brillen.ToListAsync();
        }


        // GET: api/brillens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<brillen>> Getbrillen(int id)
        {
          if (_context.brillen == null)
          {
              return NotFound();
          }
            var brillen = await _context.brillen.FindAsync(id);

            if (brillen == null)
            {
                return NotFound();
            }

            return brillen;
        }

        // POST: api/brillens
        [HttpPost]
        public async Task<ActionResult<brillen>> Postbrillen(brillen brillen)
        {
          if (_context.brillen == null)
          {
              return Problem("Entity set 'optikerdbContext.brillen'  is null.");
          }

            _context.brillen.Add(brillen);

            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (brillenExists(brillen.modellid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            
            return CreatedAtAction("Getbrillen", new { id = brillen.modellid }, brillen);
        }

        // DELETE: api/brillens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebrillen(int id)
        {
            if (_context.brillen == null)
            {
                return NotFound();
            }
            var brillen = await _context.brillen.FindAsync(id);
            if (brillen == null)
            {
                return NotFound();
            }

            _context.brillen.Remove(brillen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH api/brillens
        [HttpPatch]
        public async Task<ActionResult> Patchbrillen(int id, [FromBody] brillen cbrillen)
        {
            var brillen = await _context.brillen.FindAsync(id);
            if (brillen == null)
            {
                return NotFound();
            }

            brillen.modellid = cbrillen.modellid;
            brillen.name = cbrillen.name;
            brillen.preis = cbrillen.preis;
            brillen.art = cbrillen.art;
            brillen.glasart = cbrillen.glasart;
            brillen.stueck = cbrillen.stueck;
            brillen.staerke = cbrillen.staerke;

            return Ok();
        }

        private bool brillenExists(int id)
        {
            return (_context.brillen?.Any(e => e.modellid == id)).GetValueOrDefault();
        }
    }
}
