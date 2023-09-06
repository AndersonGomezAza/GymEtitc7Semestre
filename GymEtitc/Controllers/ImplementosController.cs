using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymEtitc.Models;

namespace GymEtitc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementosController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public ImplementosController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Implementos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Implementos>>> GetImplementos()
        {
          if (_context.Implementos == null)
          {
              return NotFound();
          }
            return await _context.Implementos.ToListAsync();
        }

        // GET: api/Implementos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Implementos>> GetImplementos(int id)
        {
          if (_context.Implementos == null)
          {
              return NotFound();
          }
            var implementos = await _context.Implementos.FindAsync(id);

            if (implementos == null)
            {
                return NotFound();
            }

            return implementos;
        }

        // PUT: api/Implementos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImplementos(int id, Implementos implementos)
        {
            if (id != implementos.IdImplemento)
            {
                return BadRequest();
            }

            _context.Entry(implementos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImplementosExists(id))
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

        // POST: api/Implementos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Implementos>> PostImplementos(Implementos implementos)
        {
          if (_context.Implementos == null)
          {
              return Problem("Entity set 'GymEtitcContext.Implementos'  is null.");
          }
            _context.Implementos.Add(implementos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImplementosExists(implementos.IdImplemento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImplementos", new { id = implementos.IdImplemento }, implementos);
        }

        // DELETE: api/Implementos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImplementos(int id)
        {
            if (_context.Implementos == null)
            {
                return NotFound();
            }
            var implementos = await _context.Implementos.FindAsync(id);
            if (implementos == null)
            {
                return NotFound();
            }

            _context.Implementos.Remove(implementos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImplementosExists(int id)
        {
            return (_context.Implementos?.Any(e => e.IdImplemento == id)).GetValueOrDefault();
        }
    }
}
