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
    public class FormaPagoesController : ControllerBase
    {
        private readonly InmobiliariaContext _context;

        public FormaPagoesController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: api/FormaPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPago>>> GetFormaPagos()
        {
            return await _context.FormaPagos.ToListAsync();
        }

        // GET: api/FormaPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> GetFormaPago(decimal id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            return formaPago;
        }

        // PUT: api/FormaPagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormaPago(decimal id, FormaPago formaPago)
        {
            if (id != formaPago.IdFormaPago)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
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

        // POST: api/FormaPagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormaPago>> PostFormaPago(FormaPago formaPago)
        {
            _context.FormaPagos.Add(formaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormaPago", new { id = formaPago.IdFormaPago }, formaPago);
        }

        // DELETE: api/FormaPagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPago(decimal id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPagos.Remove(formaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagoExists(decimal id)
        {
            return _context.FormaPagos.Any(e => e.IdFormaPago == id);
        }
    }
}
