using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Masters;

namespace qizoErpWebApiApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MUnitMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MUnitMastersController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        

        // GET: api/MUnitMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MUnitMaster>>> GetMUnitMaster()
        {
            //return IEnumerable < MUnitMaster > _context.MUnitMaster.ToList<MUnitMaster>();
            
            return await _context.MUnitMaster.ToListAsync();
        }

        // GET: api/MUnitMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MUnitMaster>> GetMUnitMaster(int id)
        {
            var mUnitMaster = await _context.MUnitMaster.FindAsync(id);

            if (mUnitMaster == null)
            {
                return NotFound();
            }

            return mUnitMaster;
        }

        // PUT: api/MUnitMasters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMUnitMaster(int id, MUnitMaster mUnitMaster)
        {
            if (id != mUnitMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(mUnitMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MUnitMasterExists(id))
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

        // POST: api/MUnitMasters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MUnitMaster>> PostMUnitMaster(MUnitMaster mUnitMaster)
        {
            _context.MUnitMaster.Add(mUnitMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMUnitMaster", new { id = mUnitMaster.Id }, mUnitMaster);
        }

        // DELETE: api/MUnitMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MUnitMaster>> DeleteMUnitMaster(int id)
        {
            var mUnitMaster = await _context.MUnitMaster.FindAsync(id);
            if (mUnitMaster == null)
            {
                return NotFound();
            }

            _context.MUnitMaster.Remove(mUnitMaster);
            await _context.SaveChangesAsync();

            return mUnitMaster;
        }

        private bool MUnitMasterExists(int id)
        {
            return _context.MUnitMaster.Any(e => e.Id == id);
        }
    }
}
