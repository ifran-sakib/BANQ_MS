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
    public class AmenityController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public AmenityController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

        // GET: api/Amenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanqAmenity>>> GetBanqAmenity()
        {
            return await _context.BanqAmenity.ToListAsync();
        }

        // GET: api/Amenity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqAmenity>> GetBanqAmenity(int id)
        {
            var banqAmenity = await _context.BanqAmenity.FindAsync(id);

            if (banqAmenity == null)
            {
                return NotFound();
            }

            return banqAmenity;
        }

        // PUT: api/Amenity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqAmenity(int id, BanqAmenity banqAmenity)
        {
            if (id != banqAmenity.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqAmenityExists(id))
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

        // POST: api/Amenity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BanqAmenity>> PostBanqAmenity(BanqAmenity banqAmenity)
        {

            if (banqAmenity.Id != 0)
            {
              
                _context.Entry(banqAmenity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanqAmenityExists(banqAmenity.Id))
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


            _context.BanqAmenity.Add(banqAmenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanqAmenity", new { id = banqAmenity.Id }, banqAmenity);
        }

        // DELETE: api/Amenity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqAmenity>> DeleteBanqAmenity(int id)
        {
            var banqAmenity = await _context.BanqAmenity.FindAsync(id);
            if (banqAmenity == null)
            {
                return NotFound();
            }

            _context.BanqAmenity.Remove(banqAmenity);
            await _context.SaveChangesAsync();

            return banqAmenity;
        }

        private bool BanqAmenityExists(int id)
        {
            return _context.BanqAmenity.Any(e => e.Id == id);
        }
    }
}
