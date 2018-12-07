using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectronicsAPI.Models;

namespace ElectronicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {
        private readonly ElectronicsdbContext _context;

        public ElectronicsController(ElectronicsdbContext context)
        {
            _context = context;
        }

        // GET: api/Electronics
        [HttpGet]
        public IEnumerable<Electronics> GetElectronics()
        {
            return _context.Electronics;
        }

        // GET: api/Electronics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectronics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var electronics = await _context.Electronics.FindAsync(id);

            if (electronics == null)
            {
                return NotFound();
            }

            return Ok(electronics);
        }

        // PUT: api/Electronics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectronics([FromRoute] int id, [FromBody] Electronics electronics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != electronics.Id)
            {
                return BadRequest();
            }

            _context.Entry(electronics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectronicsExists(id))
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

        // POST: api/Electronics
        [HttpPost]
        public async Task<IActionResult> PostElectronics([FromBody] Electronics electronics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Electronics.Add(electronics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectronics", new { id = electronics.Id }, electronics);
        }

        // DELETE: api/Electronics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectronics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var electronics = await _context.Electronics.FindAsync(id);
            if (electronics == null)
            {
                return NotFound();
            }

            _context.Electronics.Remove(electronics);
            await _context.SaveChangesAsync();

            return Ok(electronics);
        }

        private bool ElectronicsExists(int id)
        {
            return _context.Electronics.Any(e => e.Id == id);
        }
    }
}