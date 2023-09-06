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
    public class ValoracionesController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public ValoracionesController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Valoraciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Valoraciones>>> GetValoraciones()
        {
          if (_context.Valoraciones == null)
          {
              return NotFound();
          }
            return await _context.Valoraciones.ToListAsync();
        }

        // GET: api/Valoraciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Valoraciones>> GetValoraciones(int id)
        {
          if (_context.Valoraciones == null)
          {
              return NotFound();
          }
            var valoraciones = await _context.Valoraciones.FindAsync(id);

            if (valoraciones == null)
            {
                return NotFound();
            }

            return valoraciones;
        }

        // PUT: api/Valoraciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValoraciones(int id, Valoraciones valoraciones)
        {
            if (id != valoraciones.IdValoracion)
            {
                return BadRequest();
            }

            _context.Entry(valoraciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValoracionesExists(id))
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

        // POST: api/Valoraciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Valoraciones>> PostValoraciones(Valoraciones valoraciones)
        {
          if (_context.Valoraciones == null)
          {
              return Problem("Entity set 'GymEtitcContext.Valoraciones'  is null.");
          }
            _context.Valoraciones.Add(valoraciones);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValoracionesExists(valoraciones.IdValoracion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValoraciones", new { id = valoraciones.IdValoracion }, valoraciones);
        }

        // DELETE: api/Valoraciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValoraciones(int id)
        {
            if (_context.Valoraciones == null)
            {
                return NotFound();
            }
            var valoraciones = await _context.Valoraciones.FindAsync(id);
            if (valoraciones == null)
            {
                return NotFound();
            }

            _context.Valoraciones.Remove(valoraciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValoracionesExists(int id)
        {
            return (_context.Valoraciones?.Any(e => e.IdValoracion == id)).GetValueOrDefault();
        }
    }
}
