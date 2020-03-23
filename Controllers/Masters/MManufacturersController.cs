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
    public class MManufacturersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MManufacturersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MManufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MManufacturer>>> GetMManufacturer()
        {
            return await _context.MManufacturer.ToListAsync();
        }

        // GET: api/MManufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MManufacturer>> GetMManufacturer(int id)
        {
            var mManufacturer = await _context.MManufacturer.FindAsync(id);

            if (mManufacturer == null)
            {
                return NotFound();
            }

            return mManufacturer;
        }

        // PUT: api/MManufacturers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMManufacturer(int id, MManufacturer mManufacturer)
        {
            if (id != mManufacturer.MfrId)
            {
                return BadRequest();
            }

            _context.Entry(mManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MManufacturerExists(id))
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

        // POST: api/MManufacturers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MManufacturer>> PostMManufacturer(MManufacturer mManufacturer)
        {
            _context.MManufacturer.Add(mManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMManufacturer", new { id = mManufacturer.MfrId }, mManufacturer);
        }

        // DELETE: api/MManufacturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MManufacturer>> DeleteMManufacturer(int id)
        {
            var mManufacturer = await _context.MManufacturer.FindAsync(id);
            if (mManufacturer == null)
            {
                return NotFound();
            }

            _context.MManufacturer.Remove(mManufacturer);
            await _context.SaveChangesAsync();

            return mManufacturer;
        }

        private bool MManufacturerExists(int id)
        {
            return _context.MManufacturer.Any(e => e.MfrId == id);
        }
    }
}
