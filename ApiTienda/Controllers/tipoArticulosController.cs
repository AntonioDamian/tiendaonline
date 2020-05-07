using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Tienda.Models;

namespace API_Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoArticulosController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public TipoArticulosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/tipoArticulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoArticulo>>> GettipoArticulo()
        {
            return await _context.TipoArticulo.ToListAsync();
        }

        // GET: api/tipoArticulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoArticulo>> GettipoArticulo(int id)
        {
            var tipoArticulo = await _context.TipoArticulo.FindAsync(id);

            if (tipoArticulo == null)
            {
                return NotFound();
            }

            return tipoArticulo;
        }

        // PUT: api/tipoArticulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttipoArticulo(int id, TipoArticulo tipoArticulo)
        {
            if (id != tipoArticulo.TipoArticuloID)
            {
                return BadRequest();
            }

            _context.Entry(tipoArticulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoArticuloExists(id))
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

        // POST: api/tipoArticulos
        [HttpPost]
        public async Task<ActionResult<TipoArticulo>> PosttipoArticulo(TipoArticulo tipoArticulo)
        {
            _context.TipoArticulo.Add(tipoArticulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettipoArticulo", new { id = tipoArticulo.TipoArticuloID }, tipoArticulo);
        }

        // DELETE: api/tipoArticulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoArticulo>> DeletetipoArticulo(int id)
        {
            var tipoArticulo = await _context.TipoArticulo.FindAsync(id);
            if (tipoArticulo == null)
            {
                return NotFound();
            }

            _context.TipoArticulo.Remove(tipoArticulo);
            await _context.SaveChangesAsync();

            return tipoArticulo;
        }

        private bool tipoArticuloExists(int id)
        {
            return _context.TipoArticulo.Any(e => e.TipoArticuloID == id);
        }
    }
}
