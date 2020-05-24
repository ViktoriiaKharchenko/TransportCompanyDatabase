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
    public class DriversController : ControllerBase
    {
        private readonly IRepository _context ;

        public DriversController(IRepository context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }
            if (driver.FullName != null)
            {
                NameValid(driver);
            }
            if (driver.PassportNum != null)
            {
                PassportValid(driver);
            }
            if (driver.DriverLicenseNum != null)
            {
                LicenseValid(driver);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MarkAsModified<Driver>(driver);
            try
            {
                await _context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(Driver driver)
        {
            if (driver.FullName != null)
            {
                NameValid(driver);
            }
            if (driver.PassportNum != null)
            {
                PassportValid(driver);
            }
            if(driver.DriverLicenseNum != null)
            {
                LicenseValid(driver);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Drivers.Add(driver);
            await _context.Save();

            return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
        }
        

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Driver>> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.Save(); ;

            return driver;
        }
        public void NameValid(Driver driver)
        {
            if (driver.FullName.Split(new char[] { ' ' }).Length < 2) ModelState.AddModelError("FullName", "Невірний формат данних." +
                    " Введіть повне ім'я водія ");
            else
            {
                string name = driver.FullName.Split(new char[] { ' ' })[0];
                string surname = driver.FullName.Split(new char[] { ' ' })[1];
                if (name.Length < 2 || surname.Length < 2)
                {
                    ModelState.AddModelError("FullName",
                    "Невірний формат данних. Ім'я або прізвище водія занадто короткі ");
                }
                else
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if ((name[i] < 'А' || name[i] > 'ї') && name[i] != 'І')
                        {
                            ModelState.AddModelError("FullName",
                        "Невірний формат данних "); break;
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        for (int i = 0; i < surname.Length; i++)
                        {
                            if ((surname[i] < 'А' || surname[i] > 'ї') && surname[i] != 'І')
                            {
                                ModelState.AddModelError("FullName",
                            "Невірний формат данних "); break;
                            }
                        }
                    }
                }
            }
        }
        public void PassportValid(Driver driver)
        {
            if (driver.PassportNum.Length < 9) ModelState.AddModelError("PassportNum", "Номер паспорту занадто которкий");
            if (driver.PassportNum.Length > 9) ModelState.AddModelError("PassportNum", "Номер паспорту занадто довгий");
            if (ModelState.IsValid)
            {
                for (int i = 0; i < driver.PassportNum.Length; i++)
                {
                    if (driver.PassportNum[i] < '0' || driver.PassportNum[i] > '9')
                    {
                        ModelState.AddModelError("PassportNum", "Невірний формат данних");
                        break;
                    }
                }
            }
          //  var pas = _context.Drivers.Where(b => b.PassportNum == driver.PassportNum).Where(b => b.Id != driver.Id);
           // if (pas.Count() > 0) { ModelState.AddModelError("PassportNum", "Людина з таким номером паспорта вже зареєстрована в базі"); }
        }
        public void LicenseValid(Driver driver)
        {
            if (driver.DriverLicenseNum.Length < 9) ModelState.AddModelError("DriverLicenseNum", "Номер ліцензії занадто которкий");
            if (driver.DriverLicenseNum.Length > 9) ModelState.AddModelError("DriverLicenseNum", "Номер ліцензії занадто довгий");
            if (driver.DriverLicenseNum.Length == 9)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((driver.DriverLicenseNum[i] < 'А' || driver.DriverLicenseNum[i] > 'Я') && driver.DriverLicenseNum[i] != 'І')
                    {
                        ModelState.AddModelError("DriverLicenseNum", "Невірний формат данних");
                        break;
                    }
                }
                if (ModelState.IsValid)
                {
                    for (int i = 3; i < driver.DriverLicenseNum.Length; i++)
                    {
                        if (driver.DriverLicenseNum[i] < '0' || driver.DriverLicenseNum[i] > '9')
                        {
                            ModelState.AddModelError("DriverLicenseNum", "Невірний формат данних");
                            break;
                        }
                    }
                }
            }
           // IQueryable<Driver> pas = _context.Drivers.Where(b => b.DriverLicenseNum == driver.DriverLicenseNum).Where(b => b.Id != driver.Id);
            //if (pas.Count() > 0) { ModelState.AddModelError("DriverLicenseNum", "Людина з таким номером прав вже зареєстрована в базі"); }
        }
        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
