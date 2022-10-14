using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AARCOAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;

namespace AARCOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SubmarcasController : ControllerBase
    {
        private readonly AARCOContext _context;

        public SubmarcasController(AARCOContext context)
        {
            _context = context;
        }

        // GET: api/Submarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submarca>>> GetSubmarcas()
        {
            return await _context.Submarcas.ToListAsync();
        }

        // GET: api/Submarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Submarca>> GetSubmarca(int id)
        {
            var submarca = await _context.Submarcas.FindAsync(id);

          


            if (submarca == null)
            {
                return NotFound();
            }

            return submarca;
        }

        [HttpGet("GetSubMarcasByMarcasId/{idMarca}")]
        public async Task<ActionResult<Submarca>> GetSubMarcasByMarcaId(int idMarca)
            => Ok(await _context.Submarcas.Where(SubMarca => SubMarca.IdMarca == idMarca).ToListAsync());
        
            

           
        
        // PUT: api/Submarcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmarca(int id, Submarca submarca)
        {
            if (id != submarca.Id)
            {
                return BadRequest();
            }

            _context.Entry(submarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmarcaExists(id))
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

        // POST: api/Submarcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Submarca>> PostSubmarca(Submarca submarca)
        {
            _context.Submarcas.Add(submarca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubmarcaExists(submarca.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubmarca", new { id = submarca.Id }, submarca);
        }

        // DELETE: api/Submarcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmarca(int id)
        {
            var submarca = await _context.Submarcas.FindAsync(id);
            if (submarca == null)
            {
                return NotFound();
            }

            _context.Submarcas.Remove(submarca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubmarcaExists(int id)
        {
            return _context.Submarcas.Any(e => e.Id == id);
        }
    }
}
