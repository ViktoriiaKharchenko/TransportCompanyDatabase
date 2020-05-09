using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportCompanyApp.Models;

namespace TransportCompanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagonsController : ControllerBase
    {
        private readonly TransportCompanyDatabaseContext _context;

        public WagonsController(TransportCompanyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Wagons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wagon>>> GetWagons()
        {
            return await _context.Wagons.ToListAsync();
        }

        // GET: api/Wagons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wagon>> GetWagon(int id)
        {
            var wagon = await _context.Wagons.FindAsync(id);

            if (wagon == null)
            {
                return NotFound();
            }

            return wagon;
        }

        // PUT: api/Wagons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWagon(int id, Wagon wagon)
        {
            if (id != wagon.Id)
            {
                return BadRequest();
            }

            _context.Entry(wagon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WagonExists(id))
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

        // POST: api/Wagons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wagon>> PostWagon(Wagon wagon)
        {
            _context.Wagons.Add(wagon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWagon", new { id = wagon.Id }, wagon);
        }

        // DELETE: api/Wagons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wagon>> DeleteWagon(int id)
        {
            var wagon = await _context.Wagons.FindAsync(id);
            if (wagon == null)
            {
                return NotFound();
            }

            _context.Wagons.Remove(wagon);
            await _context.SaveChangesAsync();

            return wagon;
        }

        private bool WagonExists(int id)
        {
            return _context.Wagons.Any(e => e.Id == id);
        }
    }
}
