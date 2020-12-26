using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BANQ_MS.Models;

namespace BANQ_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public CustomerController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanqCustomer>>> GetBanqCustomer()
        {
            return await _context.BanqCustomer.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqCustomer>> GetBanqCustomer(int id)
        {
            var banqCustomer = await _context.BanqCustomer.FindAsync(id);

            if (banqCustomer == null)
            {
                return NotFound();
            }

            return banqCustomer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqCustomer(int id, BanqCustomer banqCustomer)
        {
            if (id != banqCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqCustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BanqCustomer>> PostBanqCustomer(BanqCustomer banqCustomer)
        {
            _context.BanqCustomer.Add(banqCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanqCustomer", new { id = banqCustomer.Id }, banqCustomer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqCustomer>> DeleteBanqCustomer(int id)
        {
            var banqCustomer = await _context.BanqCustomer.FindAsync(id);
            if (banqCustomer == null)
            {
                return NotFound();
            }

            _context.BanqCustomer.Remove(banqCustomer);
            await _context.SaveChangesAsync();

            return banqCustomer;
        }

        private bool BanqCustomerExists(int id)
        {
            return _context.BanqCustomer.Any(e => e.Id == id);
        }
    }
}
