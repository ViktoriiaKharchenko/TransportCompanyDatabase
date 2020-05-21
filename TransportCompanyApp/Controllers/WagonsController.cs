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
            return await _context.Wagons.Include(b => b.Trailer).ThenInclude(c => c.TrailerType).ToListAsync();
        }

        // GET: api/Wagons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wagon>> GetWagon(int id)
        {
            var wagon = await _context.Wagons.Where(b=>b.Id == id).Include(b => b.Trailer).ThenInclude(c => c.TrailerType).FirstAsync();

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
            if (wagon.WagonNum != null)
            {
                NumValid(wagon);
            }
            var trailer = _context.Trailers.Find(wagon.TrailerId);
            if(trailer == null)
            {
                ModelState.AddModelError("TrailerId", "Не вірно вказаний причіп");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
            if (wagon.WagonNum != null)
            {
                NumValid(wagon);
            }

            var trailer = _context.Trailers.Find(wagon.TrailerId);
            if (trailer == null)
            {
                ModelState.AddModelError("TrailerId", "Не вірно вказаний причіп");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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

        public void NumValid(Wagon wagon)
        {
            if (wagon.WagonNum.Length < 8) ModelState.AddModelError("WagonNum", "Номер фури занадто которкий");
            if (wagon.WagonNum.Length > 8) ModelState.AddModelError("WagonNum", "Номер фури занадто довгий");
            if (wagon.WagonNum.Length == 8)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (wagon.WagonNum[i] < 'A' || wagon.WagonNum[i] > 'Z')
                    {
                        ModelState.AddModelError("WagonNum", "Невірний формат данних");
                        break;
                    }
                }
                if (ModelState.IsValid)
                {
                    for (int i = 2; i < wagon.WagonNum.Length-2; i++)
                    {
                        if (wagon.WagonNum[i] < '0' || wagon.WagonNum[i] > '9')
                        {
                            ModelState.AddModelError("WagonNum", "Невірний формат данних");
                            break;
                        }
                    }
                    if (ModelState.IsValid)
                    {

                        for (int i = 6; i < 8; i++)
                        {
                            if (wagon.WagonNum[i] < 'A' || wagon.WagonNum[i] > 'Z')
                            {
                                ModelState.AddModelError("WagonNum", "Невірний формат данних");
                                break;
                            }
                        }
                    }
                }
            }
            var pas = _context.Wagons.Where(b => b.WagonNum == wagon.WagonNum).Where(b => b.Id != wagon.Id);
            if (pas.Count() > 0) { ModelState.AddModelError("WagonNum", "Фура з таким номером вже зареєстрована в базі"); }
        }
        private bool WagonExists(int id)
        {
            return _context.Wagons.Any(e => e.Id == id);
        }
    }
}
