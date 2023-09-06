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
    public class PlanesController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public PlanesController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Planes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planes>>> GetPlanes()
        {
          if (_context.Planes == null)
          {
              return NotFound();
          }
            return await _context.Planes.ToListAsync();
        }

        // GET: api/Planes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planes>> GetPlanes(int id)
        {
          if (_context.Planes == null)
          {
              return NotFound();
          }
            var planes = await _context.Planes.FindAsync(id);

            if (planes == null)
            {
                return NotFound();
            }

            return planes;
        }

        // PUT: api/Planes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanes(int id, Planes planes)
        {
            if (id != planes.IdPlan)
            {
                return BadRequest();
            }

            _context.Entry(planes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanesExists(id))
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

        // POST: api/Planes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planes>> PostPlanes(Planes planes)
        {
          if (_context.Planes == null)
          {
              return Problem("Entity set 'GymEtitcContext.Planes'  is null.");
          }
            _context.Planes.Add(planes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlanesExists(planes.IdPlan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlanes", new { id = planes.IdPlan }, planes);
        }

        // DELETE: api/Planes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanes(int id)
        {
            if (_context.Planes == null)
            {
                return NotFound();
            }
            var planes = await _context.Planes.FindAsync(id);
            if (planes == null)
            {
                return NotFound();
            }

            _context.Planes.Remove(planes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanesExists(int id)
        {
            return (_context.Planes?.Any(e => e.IdPlan == id)).GetValueOrDefault();
        }
    }
}
