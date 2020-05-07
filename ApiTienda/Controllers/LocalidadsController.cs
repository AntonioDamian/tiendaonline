using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Tienda.Models;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadsController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public LocalidadsController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Localidads
        [HttpGet]
        public IEnumerable<Localidad> GetLocalidad()
        {
            return _context.Localidad;
        }

        // GET: api/Localidads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalidad([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localidad = await _context.Localidad.FindAsync(id);

            if (localidad == null)
            {
                return NotFound();
            }

            return Ok(localidad);
        }

        // PUT: api/Localidads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad([FromRoute] string id, [FromBody] Localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localidad.ProvinciaID)
            {
                return BadRequest();
            }

            _context.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        // POST: api/Localidads
        [HttpPost]
        public async Task<IActionResult> PostLocalidad([FromBody] Localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Localidad.Add(localidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocalidadExists(localidad.ProvinciaID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocalidad", new { id = localidad.ProvinciaID }, localidad);
        }

        // DELETE: api/Localidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localidad = await _context.Localidad.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }

            _context.Localidad.Remove(localidad);
            await _context.SaveChangesAsync();

            return Ok(localidad);
        }

        private bool LocalidadExists(string id)
        {
            return _context.Localidad.Any(e => e.ProvinciaID == id);
        }
    }
}