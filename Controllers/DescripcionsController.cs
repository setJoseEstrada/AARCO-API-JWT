using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AARCOAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace AARCOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class DescripcionsController : ControllerBase
    {
        private readonly AARCOContext _context;

        public DescripcionsController(AARCOContext context)
        {
            _context = context;
        }

        [HttpGet("GetDescripcionid/{idModelo}")]
        public async Task<ActionResult<Descripcion>> GetDescripcionid(int idModelo) => Ok(await _context.Descripcions.Where(x=>x.Id==idModelo).ToListAsync());

        // GET: api/Descripcions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descripcion>>> GetDescripcions()
        {
            return await _context.Descripcions.ToListAsync();
        }

        // GET: api/Descripcions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Descripcion>> GetDescripcion(int id)
        {
            var descripcion = await _context.Descripcions.FindAsync(id);

            if (descripcion == null)
            {
                return NotFound();
            }

            return descripcion;
        }

        // PUT: api/Descripcions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescripcion(int id, Descripcion descripcion)
        {
            if (id != descripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(descripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescripcionExists(id))
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

        // POST: api/Descripcions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Descripcion>> PostDescripcion(Descripcion descripcion)
        {
            _context.Descripcions.Add(descripcion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DescripcionExists(descripcion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDescripcion", new { id = descripcion.Id }, descripcion);
        }

        // DELETE: api/Descripcions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescripcion(int id)
        {
            var descripcion = await _context.Descripcions.FindAsync(id);
            if (descripcion == null)
            {
                return NotFound();
            }

            _context.Descripcions.Remove(descripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescripcionExists(int id)
        {
            return _context.Descripcions.Any(e => e.Id == id);
        }
    }
}
