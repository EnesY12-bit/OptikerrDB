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
    public class brillensController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public brillensController(optikerdbContext context)
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

        // PUT: api/brillens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbrillen(int id, brillen brillen)
        {
            if (id != brillen.modellid)
            {
                return BadRequest();
            }

            _context.Entry(brillen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!brillenExists(id))
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

        // POST: api/brillens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        private bool brillenExists(int id)
        {
            return (_context.brillen?.Any(e => e.modellid == id)).GetValueOrDefault();
        }
    }
}
