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
    public class DriversWagonsController : ControllerBase
    {
        private readonly TransportCompanyDatabaseContext _context;

        public DriversWagonsController(TransportCompanyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DriversWagons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriversWagons>>> GetDriversWagons()
        {
            return await _context.DriversWagons.ToListAsync();
        }

        // GET: api/DriversWagons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriversWagons>> GetDriversWagons(int id)
        {
            var driversWagons = await _context.DriversWagons.FindAsync(id);

            if (driversWagons == null)
            {
                return NotFound();
            }

            return driversWagons;
        }

        // PUT: api/DriversWagons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriversWagons(int id, DriversWagons driversWagons)
        {
            if (id != driversWagons.Id)
            {
                return BadRequest();
            }

            _context.Entry(driversWagons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversWagonsExists(id))
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

        // POST: api/DriversWagons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DriversWagons>> PostDriversWagons(DriversWagons driversWagons)
        {
            _context.DriversWagons.Add(driversWagons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriversWagons", new { id = driversWagons.Id }, driversWagons);
        }

        // DELETE: api/DriversWagons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DriversWagons>> DeleteDriversWagons(int id)
        {
            var driversWagons = await _context.DriversWagons.FindAsync(id);
            if (driversWagons == null)
            {
                return NotFound();
            }

            _context.DriversWagons.Remove(driversWagons);
            await _context.SaveChangesAsync();

            return driversWagons;
        }

        private bool DriversWagonsExists(int id)
        {
            return _context.DriversWagons.Any(e => e.Id == id);
        }
    }
}
