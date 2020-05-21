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
    public class TrailersController : ControllerBase
    {
        private readonly TransportCompanyDatabaseContext _context;

        public TrailersController(TransportCompanyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Trailers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trailer>>> GetTrailers()
        {

            return await _context.Trailers.ToListAsync();
        }

        // GET: api/Trailers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trailer>> GetTrailer(int id)
        {
            var trailer = await _context.Trailers.FindAsync(id);

            if (trailer == null)
            {
                return NotFound();
            }

            return trailer;
        }

        // PUT: api/Trailers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrailer(int id, Trailer trailer)
        {
            if (id != trailer.Id)
            {
                return BadRequest();
            }
            var trailerType = _context.TrailerTypes.Find(trailer.TrailerTypeId);
            if (trailerType == null)
            {
                ModelState.AddModelError("TrailerTypeId", "Не вірно вказаний тип причіпу");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(trailer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailerExists(id))
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

        // POST: api/Trailers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trailer>> PostTrailer(Trailer trailer)
        {
            var trailerType = _context.TrailerTypes.Find(trailer.TrailerTypeId);
            if (trailerType == null)
            {
                ModelState.AddModelError("TrailerTypeId", "Не вірно вказаний тип причіпу");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trailers.Add(trailer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrailer", new { id = trailer.Id }, trailer);
        }

        // DELETE: api/Trailers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trailer>> DeleteTrailer(int id)
        {
            var trailer = await _context.Trailers.FindAsync(id);
            if (trailer == null)
            {
                return NotFound();
            }

            _context.Trailers.Remove(trailer);
            await _context.SaveChangesAsync();

            return trailer;
        }

        // GET: api/FreeTrailers
        [HttpGet("free")]
        public async Task<ActionResult<IEnumerable<Trailer>>> GetFreeTrailers()
        {
            var freeTrailers = await _context.Set<Trailer>().FromSqlRaw(@"SELECT t.* FROM Trailers t Where t.Id NOT IN(
                Select w.TrailerId From Wagons w )").Include(b=>b.TrailerType).ToListAsync();
            return freeTrailers;
        }
        private bool TrailerExists(int id)
        {
            return _context.Trailers.Any(e => e.Id == id);
        }
    }
}
