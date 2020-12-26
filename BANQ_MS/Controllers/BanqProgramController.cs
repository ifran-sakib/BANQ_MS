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
    public class BanqProgramController : ControllerBase
    {
        private readonly BANQ_MS_DBContext _context;

        public BanqProgramController(BANQ_MS_DBContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public Object GetBanqProgram()
        {
            var result = (from a in _context.BanqProgram
                          join b in _context.BanqCustomer on a.CustomerId equals b.Id
                          join c in _context.BanqInfo on a.BanqId equals c.Id

                          select new
                          {
                              a.Id,
                              a.ProgramName,
                              Customer = b.CustomerName,
                              a.ProgramDate,
                              Hall=c.Name,
                              a.NoOfPerson,
                          }
                        ).ToList();
            return result;
        }

        // GET: api/BanqProgram/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BanqProgram>> GetBanqProgram(int id)
        {
            

            var banqProgram = (from a in _context.BanqProgram
                               where a.Id == id
                         select new
                         {
                             a.Id,
                             a.ProgramName,
                             a.CustomerId,
                             a.EventMngrId,
                             a.BanqId,
                             a.ProgramDate,
                             a.StartTime,
                             a.NoOfPerson,
                             a.FoodAmount,
                             a.AmenityAmount,
                             a.HallRent,
                             a.TotalAmount,
                             a.TotalVat,
                             a.TotalServiceCharge,
                             a.TotalPayable,
                             a.TotalPaid,
                             a.DueAmount,
                             DeletedFoodItemIds = "",
                             DeletedAmenityItemIds = "",
                         }).FirstOrDefault();

            var foodItem = (from a in _context.BanqProgramFood
                                join b in _context.BanqFood on a.FoodId equals b.Id
                                where a.BanqProId == id

                                select new
                                {
                                    a.Id,
                                    a.BanqProId,
                                    a.FoodId,
                                    FoodName = b.FoodName,
                                    b.Price,
                                    a.Quantity,
                                    Total = a.Quantity * b.Price

                                }).ToList();

            var amenityItem = (from a in _context.BanqProgramAmenity
                               join b in _context.BanqAmenity on a.AmenityId equals b.Id
                               where a.BanqProId == id

                               select new
                               {
                                   a.Id,
                                   a.BanqProId,
                                   a.AmenityId,
                                   AmenityHead = b.AmenityHead,
                                   b.Cost,
                                   a.Quantity,
                                   Total = a.Quantity * b.Cost

                               }).ToList();

            var banqInfo = (from a in _context.BanqInfo
                            where a.Id == banqProgram.BanqId

                            select new
                            {
                                a.Id,
                                a.Rent,
                                a.MinimumGuest,
                                a.MaximumGuest,
                                a.VatPer,
                                a.ScPer,
                                a.Name,


                            }).FirstOrDefault();

            return Ok(new { banqProgram, foodItem , amenityItem, banqInfo });
        }

        // PUT: api/BanqProgram/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanqProgram(int id, BanqProgram banqProgram)
        {
            if (id != banqProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(banqProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqProgramExists(id))
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

        // POST: api/BanqProgram
      
        [HttpPost]
        public async Task<ActionResult<BanqProgram>> PostBanqProgram(BanqProgram banqProgram)
        {


            try
            {

                if (banqProgram.Id == 0)
                {
                    _context.BanqProgram.Add(banqProgram);
 
                }
                else
                {
                    _context.Entry(banqProgram).State = EntityState.Modified;

                    foreach (var foodItem in banqProgram.BanqProgramFood)
                    {
                        if (foodItem.Id == 0)
                        {
                            _context.BanqProgramFood.Add(foodItem);
                        }
                        else
                        {
                            _context.Entry(foodItem).State = EntityState.Modified;
                        }
                    }


                    foreach (var amenityItem in banqProgram.BanqProgramAmenity)
                    {
                        if (amenityItem.Id == 0)
                        {
                            _context.BanqProgramAmenity.Add(amenityItem);
                        }
                        else
                        {
                            _context.Entry(amenityItem).State = EntityState.Modified;
                        }
                    }


                    foreach (var id in banqProgram.DeletedFoodItemIds.Split(',').Where(x => x != ""))
                    {
                        var fooodItems = await _context.BanqProgramFood.FindAsync(Convert.ToInt32(id));
                        
                        _context.Remove(fooodItems);
                    }

                    foreach (var id in banqProgram.DeletedAmenityItemIds.Split(',').Where(x => x != ""))
                    {
                        var amenityItems = await _context.BanqProgramAmenity.FindAsync(Convert.ToInt32(id));
                       
                        _context.Remove(amenityItems);
                    }
                }


                await _context.SaveChangesAsync();

               
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BanqProgram/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BanqProgram>> DeleteBanqProgram(int id)
        {
           

            try
            {
                var banqProgram = _context.BanqProgram
                    .Include(a => a.BanqProgramFood)
                    .Include(a => a.BanqProgramAmenity)
                    .Where(a => a.Id == id).FirstOrDefault();

                if (banqProgram == null)
                {
                    return NotFound();
                }
                foreach (var item in banqProgram.BanqProgramFood)
                {
                    _context.Remove(item);
                }

                foreach (var item in banqProgram.BanqProgramAmenity)
                {
                    _context.Remove(item);
                }



                _context.BanqProgram.Remove(banqProgram);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool BanqProgramExists(int id)
        {
            return _context.BanqProgram.Any(e => e.Id == id);
        }
    }
}
