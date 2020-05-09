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
    public class TrailerTypesController : ControllerBase
    {
        private readonly TransportCompanyDatabaseContext _context;

        public TrailerTypesController(TransportCompanyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TrailerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrailerType>>> GetTrailerTypes()
        {
            return await _context.TrailerTypes.ToListAsync();
        }

        // GET: api/TrailerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrailerType>> GetTrailerType(int id)
        {
            var trailerType = await _context.TrailerTypes.FindAsync(id);

            if (trailerType == null)
            {
                return NotFound();
            }

            return trailerType;
        }

        // PUT: api/TrailerTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrailerType(int id, TrailerType trailerType)
        {
            if (id != trailerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(trailerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailerTypeExists(id))
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

        // POST: api/TrailerTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrailerType>> PostTrailerType(TrailerType trailerType)
        {
            _context.TrailerTypes.Add(trailerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrailerType", new { id = trailerType.Id }, trailerType);
        }

        // DELETE: api/TrailerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrailerType>> DeleteTrailerType(int id)
        {
            var trailerType = await _context.TrailerTypes.FindAsync(id);
            if (trailerType == null)
            {
                return NotFound();
            }

            _context.TrailerTypes.Remove(trailerType);
            await _context.SaveChangesAsync();

            return trailerType;
        }

        private bool TrailerTypeExists(int id)
        {
            return _context.TrailerTypes.Any(e => e.Id == id);
        }
    }
}
