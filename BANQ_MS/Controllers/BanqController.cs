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
    public class BanqController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public BanqController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

        // GET: api/Banq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanqInfo>>> GetBanqInfo()
        {
            return await _context.BanqInfo.ToListAsync();
        }

        // GET: api/Banq/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqInfo>> GetBanqInfo(int id)
        {
            var banqInfo = await _context.BanqInfo.FindAsync(id);

            if (banqInfo == null)
            {
                return NotFound();
            }

            return banqInfo;
        }

        // PUT: api/Banq/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqInfo(int id, BanqInfo banqInfo)
        {
            if (id != banqInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqInfoExists(id))
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

        // POST: api/Banq
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BanqInfo>> PostBanqInfo(BanqInfo banqInfo)
        {
            _context.BanqInfo.Add(banqInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanqInfo", new { id = banqInfo.Id }, banqInfo);
        }

        // DELETE: api/Banq/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqInfo>> DeleteBanqInfo(int id)
        {
            var banqInfo = await _context.BanqInfo.FindAsync(id);
            if (banqInfo == null)
            {
                return NotFound();
            }

            _context.BanqInfo.Remove(banqInfo);
            await _context.SaveChangesAsync();

            return banqInfo;
        }

        private bool BanqInfoExists(int id)
        {
            return _context.BanqInfo.Any(e => e.Id == id);
        }
    }
}
