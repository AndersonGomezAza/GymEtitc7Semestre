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
    public class ActividadesController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public ActividadesController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetActividades()
        {
          if (_context.Actividades == null)
          {
              return NotFound();
          }
            return await _context.Actividades.ToListAsync();
        }

        // GET: api/Actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividades>> GetActividades(int id)
        {
          if (_context.Actividades == null)
          {
              return NotFound();
          }
            var actividades = await _context.Actividades.FindAsync(id);

            if (actividades == null)
            {
                return NotFound();
            }

            return actividades;
        }

        // PUT: api/Actividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividades(int id, Actividades actividades)
        {
            if (id != actividades.IdActividad)
            {
                return BadRequest();
            }

            _context.Entry(actividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesExists(id))
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

        // POST: api/Actividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actividades>> PostActividades(Actividades actividades)
        {
          if (_context.Actividades == null)
          {
              return Problem("Entity set 'GymEtitcContext.Actividades'  is null.");
          }
            _context.Actividades.Add(actividades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadesExists(actividades.IdActividad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividades", new { id = actividades.IdActividad }, actividades);
        }

        // DELETE: api/Actividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividades(int id)
        {
            if (_context.Actividades == null)
            {
                return NotFound();
            }
            var actividades = await _context.Actividades.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadesExists(int id)
        {
            return (_context.Actividades?.Any(e => e.IdActividad == id)).GetValueOrDefault();
        }
    }
}
