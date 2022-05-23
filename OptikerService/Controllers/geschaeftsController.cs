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
    public class geschaeftsController : ControllerBase
    {
        private readonly optikerdbContext _context;

        public geschaeftsController(optikerdbContext context)
        {
            _context = new optikerdbContext();
        }

        // GET: api/geschaefts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<geschaeft>>> Getgeschaeft()
        {
          if (_context.geschaeft == null)
          {
              return NotFound();
          }
            return await _context.geschaeft.ToListAsync();
        }

        // GET: api/geschaefts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<geschaeft>> Getgeschaeft(int id)
        {
          if (_context.geschaeft == null)
          {
              return NotFound();
          }
            var geschaeft = await _context.geschaeft.FindAsync(id);

            if (geschaeft == null)
            {
                return NotFound();
            }

            return geschaeft;
        }

        // PUT: api/geschaefts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgeschaeft(int id, geschaeft geschaeft)
        {
            if (id != geschaeft.geschaeftsid)
            {
                return BadRequest();
            }

            _context.Entry(geschaeft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!geschaeftExists(id))
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

        // POST: api/geschaefts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<geschaeft>> Postgeschaeft(geschaeft geschaeft)
        {
          if (_context.geschaeft == null)
          {
              return Problem("Entity set 'optikerdbContext.geschaeft'  is null.");
          }
            _context.geschaeft.Add(geschaeft);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (geschaeftExists(geschaeft.geschaeftsid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgeschaeft", new { id = geschaeft.geschaeftsid }, geschaeft);
        }

        // DELETE: api/geschaefts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegeschaeft(int id)
        {
            if (_context.geschaeft == null)
            {
                return NotFound();
            }
            var geschaeft = await _context.geschaeft.FindAsync(id);
            if (geschaeft == null)
            {
                return NotFound();
            }

            _context.geschaeft.Remove(geschaeft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool geschaeftExists(int id)
        {
            return (_context.geschaeft?.Any(e => e.geschaeftsid == id)).GetValueOrDefault();
        }
    }
}
