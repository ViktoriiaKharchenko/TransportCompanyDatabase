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
    public class CustomerCompaniesController : ControllerBase
    {
        private readonly TransportCompanyDatabaseContext _context;

        public CustomerCompaniesController(TransportCompanyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCompany>>> GetCustomerCompanies()
        {
            return await _context.CustomerCompanies.ToListAsync();
        }

        // GET: api/CustomerCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCompany>> GetCustomerCompany(int id)
        {
            var customerCompany = await _context.CustomerCompanies.FindAsync(id);

            if (customerCompany == null)
            {
                return NotFound();
            }

            return customerCompany;
        }

        // PUT: api/CustomerCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCompany(int id, CustomerCompany customerCompany)
        {
            if (id != customerCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCompanyExists(id))
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

        // POST: api/CustomerCompanies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerCompany>> PostCustomerCompany(CustomerCompany customerCompany)
        {
            _context.CustomerCompanies.Add(customerCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerCompany", new { id = customerCompany.Id }, customerCompany);
        }

        // DELETE: api/CustomerCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerCompany>> DeleteCustomerCompany(int id)
        {
            var customerCompany = await _context.CustomerCompanies.FindAsync(id);
            if (customerCompany == null)
            {
                return NotFound();
            }

            _context.CustomerCompanies.Remove(customerCompany);
            await _context.SaveChangesAsync();

            return customerCompany;
        }

        private bool CustomerCompanyExists(int id)
        {
            return _context.CustomerCompanies.Any(e => e.Id == id);
        }
    }
}
