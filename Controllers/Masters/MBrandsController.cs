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
    public class MBrandsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MBrandsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBrand>>> GetMBrand()
        {
            return await _context.MBrand.ToListAsync();
        }

        // GET: api/MBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBrand>> GetMBrand(int id)
        {
            var mBrand = await _context.MBrand.FindAsync(id);

            if (mBrand == null)
            {
                return NotFound();
            }

            return mBrand;
        }

        // PUT: api/MBrands/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBrand(int id, MBrand mBrand)
        {
            if (id != mBrand.BrndId)
            {
                return BadRequest();
            }

            _context.Entry(mBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBrandExists(id))
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

        // POST: api/MBrands
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MBrand>> PostMBrand(MBrand mBrand)
        {
            _context.MBrand.Add(mBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBrand", new { id = mBrand.BrndId }, mBrand);
        }

        // DELETE: api/MBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MBrand>> DeleteMBrand(int id)
        {
            var mBrand = await _context.MBrand.FindAsync(id);
            if (mBrand == null)
            {
                return NotFound();
            }

            _context.MBrand.Remove(mBrand);
            await _context.SaveChangesAsync();

            return mBrand;
        }

        private bool MBrandExists(int id)
        {
            return _context.MBrand.Any(e => e.BrndId == id);
        }
    }
}
