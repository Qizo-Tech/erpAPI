using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;

namespace qizoErpWebApiApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class mGodownInChargesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public mGodownInChargesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/mGodownInCharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mGodownInCharge>>> GetMGodownInCharge()
        {
            return await _context.MGodownInCharge.ToListAsync();
        }

        // GET: api/mGodownInCharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mGodownInCharge>> GetmGodownInCharge(int id)
        {
            var mGodownInCharge = await _context.MGodownInCharge.FindAsync(id);

            if (mGodownInCharge == null)
            {
                return NotFound();
            }

            return mGodownInCharge;
        }

        // PUT: api/mGodownInCharges/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmGodownInCharge(int id, mGodownInCharge mGodownInCharge)
        {
            if (id != mGodownInCharge.GdnInch_Id)
            {
                return BadRequest();
            }

            _context.Entry(mGodownInCharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mGodownInChargeExists(id))
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

        // POST: api/mGodownInCharges
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<mGodownInCharge>> PostmGodownInCharge(mGodownInCharge mGodownInCharge)
        {
            _context.MGodownInCharge.Add(mGodownInCharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmGodownInCharge", new { id = mGodownInCharge.GdnInch_Id }, mGodownInCharge);
        }

        // DELETE: api/mGodownInCharges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<mGodownInCharge>> DeletemGodownInCharge(int id)
        {
            var mGodownInCharge = await _context.MGodownInCharge.FindAsync(id);
            if (mGodownInCharge == null)
            {
                return NotFound();
            }

            _context.MGodownInCharge.Remove(mGodownInCharge);
            await _context.SaveChangesAsync();

            return mGodownInCharge;
        }

        private bool mGodownInChargeExists(int id)
        {
            return _context.MGodownInCharge.Any(e => e.GdnInch_Id == id);
        }
    }
}
