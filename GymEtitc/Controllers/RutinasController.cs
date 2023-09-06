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
    public class RutinasController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public RutinasController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Rutinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rutinas>>> GetRutinas()
        {
          if (_context.Rutinas == null)
          {
              return NotFound();
          }
            return await _context.Rutinas.ToListAsync();
        }

        // GET: api/Rutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rutinas>> GetRutinas(int id)
        {
          if (_context.Rutinas == null)
          {
              return NotFound();
          }
            var rutinas = await _context.Rutinas.FindAsync(id);

            if (rutinas == null)
            {
                return NotFound();
            }

            return rutinas;
        }

        // PUT: api/Rutinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutinas(int id, Rutinas rutinas)
        {
            if (id != rutinas.IdRutina)
            {
                return BadRequest();
            }

            _context.Entry(rutinas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutinasExists(id))
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

        // POST: api/Rutinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rutinas>> PostRutinas(Rutinas rutinas)
        {
          if (_context.Rutinas == null)
          {
              return Problem("Entity set 'GymEtitcContext.Rutinas'  is null.");
          }
            _context.Rutinas.Add(rutinas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RutinasExists(rutinas.IdRutina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRutinas", new { id = rutinas.IdRutina }, rutinas);
        }

        // DELETE: api/Rutinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutinas(int id)
        {
            if (_context.Rutinas == null)
            {
                return NotFound();
            }
            var rutinas = await _context.Rutinas.FindAsync(id);
            if (rutinas == null)
            {
                return NotFound();
            }

            _context.Rutinas.Remove(rutinas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutinasExists(int id)
        {
            return (_context.Rutinas?.Any(e => e.IdRutina == id)).GetValueOrDefault();
        }
    }
}
