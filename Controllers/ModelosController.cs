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
    //[Authorize]
    public class ModelosController : ControllerBase
    {
        private readonly AARCOContext _context;

        public ModelosController(AARCOContext context)
        {
            _context = context;
        }

        // GET: api/Modelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos()
        {
            return await _context.Modelos.ToListAsync();
        }


        [HttpGet("GetModelosid/{idSubmarca}")]
        public async Task<ActionResult<Modelo>> GetModelosid(int idSubmarca)=> Ok(await _context.Modelos.Where(x=>x.IdSubMarca==idSubmarca).ToListAsync());





        // GET: api/Modelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modelos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
            _context.Modelos.Add(modelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModeloExists(modelo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModelo", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.Id == id);
        }
    }
}
