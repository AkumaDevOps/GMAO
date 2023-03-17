using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMAOModel.Models;

namespace GMAOMinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesRepuestosController : ControllerBase
    {
        private readonly GmaoContext _context;

        public AlmacenesRepuestosController(GmaoContext context)
        {
            _context = context;
        }

        // GET: api/AlmacenesRepuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlmacenesRepuesto>>> GetAlmacenesRepuestos()
        {
          if (_context.AlmacenesRepuestos == null)
          {
              return NotFound();
          }
            foreach (AlmacenesRepuesto item in _context.AlmacenesRepuestos)
            {
                using (GmaoContext context = new GmaoContext())
                {
                    item.IdalmacenNavigation = await context.Almacenes.FindAsync(item.Idalmacen) ?? new Almacene();
                };
                using (GmaoContext context = new GmaoContext())
                {
                    item.IdrepuestosNavigation= await context.Repuestos.FindAsync(item.Idrepuestos) ?? new Repuesto();
                };
            }
            return await _context.AlmacenesRepuestos.ToListAsync();

        }

        // GET: api/AlmacenesRepuestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlmacenesRepuesto>> GetAlmacenesRepuesto(int id)
        {
          if (_context.AlmacenesRepuestos == null)
          {
              return NotFound();
          }
            var almacenesRepuesto = await _context.AlmacenesRepuestos.FindAsync(id);

            if (almacenesRepuesto == null)
            {
                return NotFound();
            }
            using (GmaoContext context = new GmaoContext())
            {
            almacenesRepuesto.IdalmacenNavigation = await context.Almacenes.FindAsync(almacenesRepuesto.Idalmacen) ?? new Almacene();
            };
            using (GmaoContext context = new GmaoContext())
            {
            almacenesRepuesto.IdrepuestosNavigation = await context.Repuestos.FindAsync(almacenesRepuesto.Idrepuestos) ?? new Repuesto();
            };
            return almacenesRepuesto;
        }

        // PUT: api/AlmacenesRepuestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacenesRepuesto(int id, AlmacenesRepuesto almacenesRepuesto)
        {
            if (id != almacenesRepuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(almacenesRepuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenesRepuestoExists(id))
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

        // POST: api/AlmacenesRepuestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlmacenesRepuesto>> PostAlmacenesRepuesto(AlmacenesRepuesto almacenesRepuesto)
        {
          if (_context.AlmacenesRepuestos == null)
          {
              return Problem("Entity set 'GmaoContext.AlmacenesRepuestos'  is null.");
          }
            _context.AlmacenesRepuestos.Add(almacenesRepuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlmacenesRepuesto", new { id = almacenesRepuesto.Id }, almacenesRepuesto);
        }

        // DELETE: api/AlmacenesRepuestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacenesRepuesto(int id)
        {
            if (_context.AlmacenesRepuestos == null)
            {
                return NotFound();
            }
            var almacenesRepuesto = await _context.AlmacenesRepuestos.FindAsync(id);
            if (almacenesRepuesto == null)
            {
                return NotFound();
            }

            _context.AlmacenesRepuestos.Remove(almacenesRepuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlmacenesRepuestoExists(int id)
        {
            return (_context.AlmacenesRepuestos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
