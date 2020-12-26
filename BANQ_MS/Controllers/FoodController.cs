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
    public class FoodController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public FoodController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

        // GET: api/Food
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanqFood>>> GetBanqFood()
        {
            return await _context.BanqFood.ToListAsync();
        }

        // GET: api/Food/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqFood>> GetBanqFood(int id)
        {
            var banqFood = await _context.BanqFood.FindAsync(id);

            if (banqFood == null)
            {
                return NotFound();
            }

            return banqFood;
        }

        // PUT: api/Food/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqFood(int id, BanqFood banqFood)
        {
            if (id != banqFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqFoodExists(id))
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

        // POST: api/Food
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BanqFood>> PostBanqFood(BanqFood banqFood)
        {
            if (banqFood.Id != 0)
            {
                banqFood.FoodCategoryId = 1;
                _context.Entry(banqFood).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanqFoodExists(banqFood.Id))
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


            banqFood.FoodCategoryId = 1;
            _context.BanqFood.Add(banqFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanqFood", new { id = banqFood.Id }, banqFood);
        }

        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqFood>> DeleteBanqFood(int id)
        {
            var banqFood = await _context.BanqFood.FindAsync(id);
            if (banqFood == null)
            {
                return NotFound();
            }

            _context.BanqFood.Remove(banqFood);
            await _context.SaveChangesAsync();

            return banqFood;
        }

        private bool BanqFoodExists(int id)
        {
            return _context.BanqFood.Any(e => e.Id == id);
        }
    }
}
