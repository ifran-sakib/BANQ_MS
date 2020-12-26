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
    public class BanqEvntMngrController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public BanqEvntMngrController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

        // GET: api/BanqEvntMngr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanqEventManager>>> GetBanqEventManager()
        {
            return await _context.BanqEventManager.ToListAsync();
        }

        // GET: api/BanqEvntMngr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqEventManager>> GetBanqEventManager(int id)
        {
            var banqEventManager = await _context.BanqEventManager.FindAsync(id);

            if (banqEventManager == null)
            {
                return NotFound();
            }

            return banqEventManager;
        }

        // PUT: api/BanqEvntMngr/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqEventManager(int id, BanqEventManager banqEventManager)
        {
            if (id != banqEventManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqEventManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqEventManagerExists(id))
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

        // POST: api/BanqEvntMngr
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BanqEventManager>> PostBanqEventManager(BanqEventManager banqEventManager)
        {
            _context.BanqEventManager.Add(banqEventManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanqEventManager", new { id = banqEventManager.Id }, banqEventManager);
        }

        // DELETE: api/BanqEvntMngr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqEventManager>> DeleteBanqEventManager(int id)
        {
            var banqEventManager = await _context.BanqEventManager.FindAsync(id);
            if (banqEventManager == null)
            {
                return NotFound();
            }

            _context.BanqEventManager.Remove(banqEventManager);
            await _context.SaveChangesAsync();

            return banqEventManager;
        }

        private bool BanqEventManagerExists(int id)
        {
            return _context.BanqEventManager.Any(e => e.Id == id);
        }
    }
}
