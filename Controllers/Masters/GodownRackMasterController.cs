using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GodownRackMasterController : ControllerBase
    {
        private readonly AppDBContext _context;

        public GodownRackMasterController(AppDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<MGodown>> PostMGodown(MGodown mGodown)
        {
            _context.mGodown.Add(mGodown);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMGodown", new { id = mGodown.Gdn_Id }, mGodown);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMGodown(int id, MGodown mGodown)
        {
            if (id != mGodown.Gdn_Id)
            {
                return BadRequest();
            }

            _context.Entry(mGodown).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MGodownExists(id))
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
        private bool MGodownExists(int id)
        {
            return _context.mGodown.Any(e => e.Gdn_Id == id);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MGodown>>> GetMGodown()
        {
            //////return await _context.mGodown.ToListAsync();
            //////return await _context.mGodown
            //////    .FromSqlInterpolated($"SELECT * FROM mGodown")
            //////    .Include(b => b.Racks).ToListAsync();
            //////  .Include(c=> c.incharge)
            return await _context.mGodown.Include(p => p.Racks)
                              .ToListAsync();

        }

        // GET: api/MGodowns/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult<MGodown>> GetMGodown(int id)
        {
            return await _context.mGodown.Include(p => p.Racks).FirstOrDefaultAsync(p => p.Gdn_Id == id);

        }

        //to map keys with DTO class
        private static mGodownModelDTO AssingToDTO(MGodown obj) =>
           new mGodownModelDTO
           {

                Id = obj.Gdn_Id ,
                Description = obj.gdn_Description ,
                InChargeID =obj.gdn_InCharge ,
                ContactNumber =obj.gdn_ContactNumber ,
                gdnAddress=obj.gdn_Address ,
                UserId = obj.gdn_UserId,
                BranchId = obj.gdn_BranchId
                //,Rackdetails=obj.rackdetails 
               

           };

    }
}