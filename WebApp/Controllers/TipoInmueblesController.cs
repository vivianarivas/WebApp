using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInmueblesController : ControllerBase
    {
        private readonly InmobiliariaContext _context;

        public TipoInmueblesController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: api/TipoInmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInmueble>>> GetTipoInmuebles()
        {
            return await _context.TipoInmuebles.ToListAsync();
        }

        // GET: api/TipoInmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInmueble>> GetTipoInmueble(decimal id)
        {
            var tipoInmueble = await _context.TipoInmuebles.FindAsync(id);

            if (tipoInmueble == null)
            {
                return NotFound();
            }

            return tipoInmueble;
        }

        // PUT: api/TipoInmuebles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInmueble(decimal id, TipoInmueble tipoInmueble)
        {
            if (id != tipoInmueble.IdTipoInmueble)
            {
                return BadRequest();
            }

            _context.Entry(tipoInmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInmuebleExists(id))
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

        // POST: api/TipoInmuebles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoInmueble>> PostTipoInmueble(TipoInmueble tipoInmueble)
        {
            _context.TipoInmuebles.Add(tipoInmueble);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoInmueble", new { id = tipoInmueble.IdTipoInmueble }, tipoInmueble);
        }

        // DELETE: api/TipoInmuebles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInmueble(decimal id)
        {
            var tipoInmueble = await _context.TipoInmuebles.FindAsync(id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }

            _context.TipoInmuebles.Remove(tipoInmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInmuebleExists(decimal id)
        {
            return _context.TipoInmuebles.Any(e => e.IdTipoInmueble == id);
        }
    }
}
