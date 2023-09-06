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
    public class MaquinariasController : ControllerBase
    {
        private readonly GymEtitcContext _context;

        public MaquinariasController(GymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Maquinarias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquinarias>>> GetMaquinarias()
        {
          if (_context.Maquinarias == null)
          {
              return NotFound();
          }
            return await _context.Maquinarias.ToListAsync();
        }

        // GET: api/Maquinarias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquinarias>> GetMaquinarias(int id)
        {
          if (_context.Maquinarias == null)
          {
              return NotFound();
          }
            var maquinarias = await _context.Maquinarias.FindAsync(id);

            if (maquinarias == null)
            {
                return NotFound();
            }

            return maquinarias;
        }

        // PUT: api/Maquinarias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinarias(int id, Maquinarias maquinarias)
        {
            if (id != maquinarias.IdMaquinaria)
            {
                return BadRequest();
            }

            _context.Entry(maquinarias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinariasExists(id))
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

        // POST: api/Maquinarias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maquinarias>> PostMaquinarias(Maquinarias maquinarias)
        {
          if (_context.Maquinarias == null)
          {
              return Problem("Entity set 'GymEtitcContext.Maquinarias'  is null.");
          }
            _context.Maquinarias.Add(maquinarias);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaquinariasExists(maquinarias.IdMaquinaria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaquinarias", new { id = maquinarias.IdMaquinaria }, maquinarias);
        }

        // DELETE: api/Maquinarias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquinarias(int id)
        {
            if (_context.Maquinarias == null)
            {
                return NotFound();
            }
            var maquinarias = await _context.Maquinarias.FindAsync(id);
            if (maquinarias == null)
            {
                return NotFound();
            }

            _context.Maquinarias.Remove(maquinarias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaquinariasExists(int id)
        {
            return (_context.Maquinarias?.Any(e => e.IdMaquinaria == id)).GetValueOrDefault();
        }
    }
}
